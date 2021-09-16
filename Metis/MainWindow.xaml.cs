using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Collections.ObjectModel;

using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;
using System.Net;
using System.Collections.Specialized;
using MahApps.Metro.Controls;
using System.Windows.Controls.Primitives;
using Firebase.Database;
using Firebase.Auth;
using Firebase;

namespace Metis
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<TaskInfo> taskList = new ObservableCollection<TaskInfo>();
        public ObservableCollection<TaskInfo> TaskList { get => taskList; set { taskList = value; } }

        private string currentSpaceTab = null; // refers to currently selected spacetab
        public string CurrentSpaceTab { get => currentSpaceTab; set { currentSpaceTab = value; loadTaskTable(); } }

        public MainWindow()
        {
            // TODO: login via email
            // initializing application
            InitializeComponent();
            loadProfiles(); // loads profile names into profile list from database
            loadTaskTable(); // loads tasks from DB and loads into taskList
        }

        /* Loads Spaces in main window*/
        public void loadSpaces()
        {
            // clear spaces section out before reading into it
            // :: prevent duplicates
            SpacesSection.Children.Clear();

            // retrieve JSON data from database based on profile
            string CurrentProfileName = ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();
            List<SpaceObject> spacesList = JSONtoListOfSpaceObjects(CurrentProfileName);

            // add into children
            foreach (SpaceObject spaceObject in spacesList)
            {
                SpaceTabs spaceTab = new SpaceTabs(spaceObject.SpaceName);
                spaceTab.Background = System.Windows.Media.Brushes.Transparent;
                spaceTab.Owner = this;
                spaceTab.ParentProfileName = CurrentProfileName;
                
                // keeps track of current spaceTab name
                spaceTab.PreviewMouseLeftButtonDown += (sender, e) => {
                    if (CurrentSpaceTab == spaceObject.SpaceName)
                        CurrentSpaceTab = null; // so user can re-click to re-null & get blank page
                    else
                        CurrentSpaceTab = spaceObject.SpaceName;
                }; ;

                // add to spaces section
                SpacesSection.Children.Add(spaceTab);
            }
        }

        /* Gets Profile List... no params */
        public static List<String> GetProfileList()
        {
            string query = "SELECT profileName FROM [data];";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable.AsEnumerable().Select(x => x[0].ToString()).ToList();
        }

        /* Returns Profile List... params */
        // NOTE: assumes datatable is filled/initialized
        public static List<String> GetProfileList(ref DataTable dataTable) { return dataTable.AsEnumerable().Select(x => x[0].ToString()).ToList(); }

        /* Returns a datatable based on query... doesn't support parameters*/
        public static DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        /* Loads profiles */
        public void loadProfiles()
        {
            /* Try loading profile list */
            try
            {
                // query database & get list of profileNames (column)
                string query = "SELECT profileName FROM [data];";
                DataTable dataTable = GetDataTable(query);

                // read into profileList
                List<String> profileList = GetProfileList(ref dataTable);
                bool createdNew = false;

                // if profileList is empty, add a default
                if (profileList.Count == 0)
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
                    {
                        // add to query
                        string addQuery = "INSERT INTO data VALUES (1, 'Default', '')";
                        using (SqlCommand command = new SqlCommand(addQuery))
                        {
                            command.Connection = connection;
                            connection.Open();
                            command.ExecuteReader();
                        }

                        // default created flag
                        createdNew = true;
                        profileList.Add("Default");
                    }
                }

                // add a edit profile(s) button
                profileList.Add("Edit profile(s)");

                // adds XAML code to profile list dropdown based on info read
                ProfileDropDownList.ItemsSource = profileList;

                // if a default profile was created, make it selected
                if (createdNew)
                {
                    ProfileDropDownList.SelectedIndex = 0;
                    Properties.Settings.Default.Last_Selected_Index = 0; // refers to selected index
                    Properties.Settings.Default.TotalDBRows = 1;
                }

                // otherwise, pick last selected
                else
                    ProfileDropDownList.SelectedIndex = Properties.Settings.Default.Last_Selected_Index;
            }

            /* Catch exceptions from loading profile list */
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }

        /* Prompts new window for Space creation */
        private void openCreateSpaceWindow(object sender, RoutedEventArgs e)
        {
            SpaceForm spaceFormWindow = new SpaceForm();
            spaceFormWindow.Owner = this;
            spaceFormWindow.ShowDialog();
        }

        /* Creates new settings window */
        private void openSettingsWindow(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.ShowDialog();
        }

        /* Takes care of when drop down list changes */
        private void ProfileDropDownList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex + 1 != comboBox.Items.Count)
            {
                Properties.Settings.Default.Last_Selected_Index = comboBox.SelectedIndex;
                loadSpaces();
            }

            else
            {
                // open new profile form
                ProfileForm profileForm = new ProfileForm();
                profileForm.Owner = this;
                profileForm.ShowDialog();
                comboBox.SelectedIndex = Properties.Settings.Default.Last_Selected_Index;
            }
        }

        /* Saves application settings on close */
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // saves all changed settings on exit
            Properties.Settings.Default.Save();

            // TODO: saves to firebase if wifi is avaliable
            //var auth = "AIzaSyAVu6ozm6DFrBx6TRnNlzgHz0NIbtH0nds";
            //var firebaseClient = new FirebaseClient("metis-tiles.firebaseapp.com");
        }
        
        /* Gets JSON data from DB and converts it into List<SpaceObject>*/
        public static List<SpaceObject> JSONtoListOfSpaceObjects(string profileName)
        {
            // retrieve JSON data from database based on profile
            List<SpaceObject> spacesList = new List<SpaceObject>(0); // TODO: change from 0 to a variable to improve performance
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
            {
                connection.Open();
                string query = "SELECT spacesJSON FROM [data] WHERE profileName = @v1;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter param = new SqlParameter("@v1", profileName);
                    command.Parameters.Add(param);
                    SqlDataReader data = command.ExecuteReader();

                    // deserialize into spaceslist
                    // read into SpaceList and convert into List<SpaceObject>
                    while (data.Read())
                    {
                        string JSON = ((IDataRecord)data)[0].ToString();
                        if (JSON.Length == 0)
                            break;
                        spacesList = JsonSerializer.Deserialize<SpacesList>(JSON).GetSpacesList();
                    }

                    // close after done reading
                    data.Close();
                }
            }
            return spacesList;
        }

        /* Takes modified SpacesList, reserializes it, and puts into DB based on profileName*/
        public static void ListOfSpaceObjectstoJSON(ref SpacesList spacesList, string CurrentProfileName)
        {
            string newJSON = JsonSerializer.Serialize<SpacesList>(spacesList);

            // update SQL table with new JSON
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE data SET spacesJSON = @newJSON WHERE profileName = @pn", connection))
                {
                    connection.Open();
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@newJSON";
                    param.Value = newJSON;

                    sqlCommand.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@pn";
                    param2.Value = CurrentProfileName;

                    sqlCommand.Parameters.Add(param2);

                    sqlCommand.ExecuteReader();
                }
            }
        }

        /* Updates database on taskList change */
        private void updateDBSpaceData(object sender, DataGridCellEditEndingEventArgs e)
        {
            // TODO: if no name, no date, and no notes, delete row
            // .... also maybe don't allow empty name
            // decide whether updating text or datetimepicker
            object EditedCellText = null;

            if (e.EditingElement.GetType() == typeof(TextBox))
                EditedCellText = ((TextBox)e.EditingElement).Text;

            else if (e.EditingElement.GetType() == typeof(ContentPresenter))
            {
                EditedCellText = ((ContentPresenter)e.EditingElement).Content;
                ContentPresenter cp = (ContentPresenter)e.EditingElement;
                DateTimePicker dtp = (DateTimePicker)cp.ContentTemplate.FindName("DueDatePicker", cp);
                EditedCellText = dtp.SelectedDateTime;
            }

            DataGrid dg = (DataGrid)sender;
            // retrieve JSON data from database based on profile
            string CurrentProfileName = ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();
            List<SpaceObject> spaceObjects = JSONtoListOfSpaceObjects(CurrentProfileName);

            bool meaningfulChanges = false;
            // find current space and update DB
            for (int i = 0; i < spaceObjects.Count; i++)
            {
                if (spaceObjects[i].SpaceName == CurrentSpaceTab)
                {
                    int row = dg.SelectedIndex;

                    // case: new page/space
                    if (spaceObjects[i].SpaceData == null)
                        spaceObjects[i].SpaceData = new ObservableCollection<TaskInfo>();

                    // case: add
                    if (row >= spaceObjects[i].SpaceData.Count)
                    {
                        spaceObjects[i].SpaceData.Add(new TaskInfo());
                        // added row, will now "modify" in proceeding code
                    }

                    // case: modify/remove
                    TaskInfo currentTaskInfo = spaceObjects[i].SpaceData[row];

                    if (e.Column.DisplayIndex == 0 && currentTaskInfo.TaskName != (string)EditedCellText)
                    {
                        currentTaskInfo.TaskName = (string)EditedCellText;
                        meaningfulChanges = true;
                    }

                    else if (e.Column.DisplayIndex == 2 && currentTaskInfo.Notes != (string)EditedCellText)
                    {
                        currentTaskInfo.Notes = (string)EditedCellText;
                        meaningfulChanges = true;
                    }

                    else if (e.Column.DisplayIndex == 1 && currentTaskInfo.DueDate != (DateTime?)EditedCellText)
                    {
                        currentTaskInfo.DueDate = (DateTime?)EditedCellText;
                        meaningfulChanges = true;
                    }

                    break;
                }
            }

            // reserialize back into DB 
            if (meaningfulChanges) // don't do all that work if nothing was changed
            {
                SpacesList spacesList = new SpacesList(spaceObjects);
                ListOfSpaceObjectstoJSON(ref spacesList, CurrentProfileName);
            }
        }
        //private async void loadPanels()
        //{
        //    //// grab results from giphy
        //    //int n = 4;
        //    //var giphy = new Giphy("SYgS7NmgV77zaVaCf0iXpwHc5Fve8VZ7");
        //    //var searchParameter = new SearchParameter()
        //    //{
        //    //    Query = "night city"
        //    //};
        //    //// Returns gif results
        //    //GiphyDotNet.Model.Results.GiphySearchResult gifResult = await giphy.GifSearch(searchParameter);

        //    //// establish brushes
        //    //List<SolidColorBrush> brushes = new List<SolidColorBrush>(n);
        //    //brushes.Add(System.Windows.Media.Brushes.Chartreuse);
        //    //brushes.Add(System.Windows.Media.Brushes.Red);
        //    //brushes.Add(System.Windows.Media.Brushes.Blue);
        //    //brushes.Add(System.Windows.Media.Brushes.Yellow);

        //    //// get some sample text
        //    //List<string> texts = new List<string>(n);
        //    //for (int i = 1; i <= n; i++) { texts.Add(String.Format("text{0}", i)); }

        //    //// TODO: in future, it should only download once, then just read from local... ie: read from database
        //    //// grab results from giphy, download to local, and read them into images. load these images into items List
        //    //ObservableCollection<UIElement> items = new ObservableCollection<UIElement>();
        //    //for (int i = 0; i < n; i++)
        //    //{
        //    //    WebRequest request = System.Net.WebRequest.Create(gifResult.Data[i].Images.FixedHeightDownsampled.Url);
        //    //    using (System.Net.WebResponse response = request.GetResponse())
        //    //    {
        //    //        byte[] buffer = new byte[Convert.ToInt32(gifResult.Data[i].Images.FixedHeightDownsampled.Size)];
        //    //        FileStream target = new FileStream(gifResult.Data[i].Id + ".gif", FileMode.Create, FileAccess.ReadWrite);
        //    //        int read;
        //    //        while ((read = response.GetResponseStream().Read(buffer, 0, buffer.Length)) > 0) { target.Write(buffer, 0, read); }
        //    //        BitmapImage bitmapImage = new BitmapImage();
        //    //        bitmapImage.BeginInit();
        //    //        bitmapImage.StreamSource = target;
        //    //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //    //        bitmapImage.EndInit();
        //    //        bitmapImage.Freeze();
        //    //        System.Windows.Controls.Image newImage = new System.Windows.Controls.Image();
        //    //        newImage.Stretch = Stretch.Fill;
        //    //        WpfAnimatedGif.ImageBehavior.SetAnimatedSource(newImage, bitmapImage);

        //    //        WrapPanelItem item = new WrapPanelItem(panel.ItemWidth, panel.ItemHeight);
        //    //        item.Background = brushes[i];
        //    //        item.Text = texts[i];
        //    //        item.Foreground = System.Windows.Media.Brushes.Lime;
        //    //        item.ParentWrapPanel = panel; // set parent to refer to later

        //    //        item.PanelItemGrid.Children.Add(newImage);
        //    //        items.Add(item);
        //    //    }
        //    //}

        //    //WrapPanelItem settings = new WrapPanelItem(panel.ItemWidth, panel.ItemHeight);
        //    //settings.Background = System.Windows.Media.Brushes.BlueViolet;
        //    //settings.ParentWrapPanel = panel;
        //    //BitmapImage settingsSRC = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\resources\\settings_gear.png"));
        //    //System.Windows.Controls.Image settingsIcon = new System.Windows.Controls.Image();
        //    //settingsIcon.Height = 200;
        //    //settingsIcon.Width = 200;
        //    //settingsSRC.Freeze();
        //    //settingsIcon.Source = settingsSRC;
        //    //settings.PanelItemGrid.Children.Add(settingsIcon);

        //    //settings.MouseLeftButtonDown += openSettingsWindow;

        //    //WrapPanelItem addTile = new WrapPanelItem(panel.ItemWidth, panel.ItemHeight);
        //    //addTile.Background = System.Windows.Media.Brushes.Violet;
        //    //addTile.ParentWrapPanel = panel;
        //    //BitmapImage addTileSRC = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\resources\\plus.png"));
        //    //System.Windows.Controls.Image addTilesIcon = new System.Windows.Controls.Image();
        //    //addTilesIcon.Height = 200;
        //    //addTilesIcon.Width = 200;
        //    //addTileSRC.Freeze();
        //    //addTilesIcon.Source = addTileSRC;
        //    //addTile.PanelItemGrid.Children.Add(addTilesIcon);

        //    //addTile.MouseLeftButtonDown += openAddTileWindow;

        //    //items.Add(settings);
        //    //items.Add(addTile);

        //    //// TODO: make something out of this...
        //    //// TODO: store this type of data in database JSON
        //    //// TODO: pull and load from JSON to here
        //    //// set panel source to image items list
        //    //panel.ItemsSource = items;
        //}

        private void inviteToTile(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("TODO: Invite to Tile");
        }

        /* Loads spaceData from DB to TaskTable */
        private void loadTaskTable()
        {
            if (CurrentSpaceTab == null)
            {
                // display blank white screen
                TaskTable.Visibility = Visibility.Hidden;
            } else
            {
                TaskTable.Visibility = Visibility.Visible;

                // load to TaskTable
                string CurrentProfileName = ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();
                List<SpaceObject> spaceObjects = JSONtoListOfSpaceObjects(CurrentProfileName);

                // find current space
                foreach(SpaceObject ob in spaceObjects)
                    if (ob.SpaceName == this.CurrentSpaceTab)
                    {
                        // update taskList accordingly
                        TaskList.Clear();
                        if (ob.SpaceData != null)
                            foreach (TaskInfo ti in ob.SpaceData)
                            { // doing manually to raise event for binding
                                TaskList.Add(ti);
                            }
                        break;
                    }
            }
        }
        /* removes from tasktable and from DB */
        private void DeleteTaskTableRow(object sender, RoutedEventArgs e)
        {
            int curr_index = TaskTable.SelectedIndex;

            if (curr_index + 1 >= TaskTable.Items.Count)
                return;

            TaskInfo curr = (TaskInfo)TaskTable.CurrentItem;
            // remove from task table
            TaskList.Remove(curr);

            // remove from DB
            // retrieve JSON data from database based on profile
            string CurrentProfileName = ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();
            List<SpaceObject> spaceObjects = JSONtoListOfSpaceObjects(CurrentProfileName);
            foreach (SpaceObject ob in spaceObjects)
                if (ob.SpaceName == currentSpaceTab)
                {
                    ob.SpaceData.RemoveAt(curr_index);

                    if (ob.SpaceData.Count == 0) // re-nulls on empty... flags that new ObservableCollection<TaskInfo> is needed 
                        ob.SpaceData = null;

                    break;
                }

            // reserialize back into DB 
            SpacesList spacesList = new SpacesList(spaceObjects);
            ListOfSpaceObjectstoJSON(ref spacesList, CurrentProfileName);
        }

        /* disables header column context menu */
        private void HandleContextMenu(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = TaskTable.ContextMenu;

            if (cm.IsOpen)
            {
                cm.IsOpen = false; // close menu
                cm.IsEnabled = true; // reset state
            }
            else
            {
                DependencyObject depObj = (DependencyObject)e.OriginalSource;

                while ((depObj != null) && !(depObj is DataGridColumnHeader))
                    depObj = VisualTreeHelper.GetParent(depObj);

                if (depObj is DataGridColumnHeader)
                    cm.IsEnabled = false;
                else // is null
                    cm.IsEnabled = true;
            }
        }
    }
}