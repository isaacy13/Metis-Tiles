using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Metis
{
    public partial class ProfileForm : Window
    {
        public ProfileForm()
        {
            InitializeComponent();
            LoadProfileList();
        }

        private void LoadProfileList()
        {
            ProfileEditListView.ItemsSource = (List<string>)MainWindow.GetProfileList();
        }

        private void addProfile(object sender, RoutedEventArgs e)
        {
            // query database & get list of profileNames (column)
            string query = "SELECT profileName FROM [data];";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);

                    // read into profileList
                    List<String> profileList = new List<String>();
                    profileList = dataTable.AsEnumerable().Select(x => x[0].ToString()).ToList();

                    string newProfileNameString = newProfileName.Text.Trim(' '); // trims off whitespace

                    try
                    {
                        if (IsValidProfileName(newProfileNameString, ref profileList))
                        {
                            query = "INSERT INTO data (Id,profileName,spacesJSON) VALUES (@v1, @v2, @v3)";

                            connection.Open();
                            // create new row in sql data table
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                SqlParameter param1 = new SqlParameter("@v1", SqlDbType.Int);
                                param1.Value = Properties.Settings.Default.TotalDBRows + 1;

                                SqlParameter param2 = new SqlParameter("@v2", SqlDbType.NChar);
                                param2.Value = newProfileNameString;

                                SqlParameter param3 = new SqlParameter("@v3", SqlDbType.NVarChar);
                                param3.Value = "";

                                command.Parameters.Add(param1);
                                command.Parameters.Add(param2);
                                command.Parameters.Add(param3);

                                command.ExecuteReader();
                            }

                            // update db row count
                            Properties.Settings.Default.TotalDBRows++;

                            // reload profiles
                            MainWindow mainWindow = Owner as MainWindow;
                            if (mainWindow != null)
                                mainWindow.loadProfiles();

                            // update last selected index to newly created
                            // NOTE: minus 2 accounts for add profile selection
                            // and 0-indexing difference
                            Properties.Settings.Default.Last_Selected_Index = mainWindow.ProfileDropDownList.Items.Count - 2;

                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            
            this.Close();
        }

        private void removeProfile(object sender, RoutedEventArgs e)
        {
            // get list of profiles to remove
            var profilesToRemove = ProfileEditListView.SelectedItems;

            if (MainWindow.GetProfileList().Count - profilesToRemove.Count < 1)
            {
                MessageBox.Show("Must have at least one active profile");
                return;
            }

            // set up database query
            string query = "DELETE FROM [data] WHERE profileName = @v1;";
            bool CurrentProfileRemoved = false;

            MainWindow mainWindow = Owner as MainWindow;
            string CurrentProfileName = mainWindow.ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();

            try
            {
                // remove each profile in list from database
                foreach (string s in profilesToRemove)
                {
                    // keeps track of flag to see if currently selected profile
                    // is removed or not
                    if (s.Equals(CurrentProfileName))
                        CurrentProfileRemoved = true;

                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@v1", SqlDbType.NChar);
                            command.Parameters["@v1"].Value = s;
                            connection.Open();
                            command.ExecuteReader();
                        }
                    }
                }
            } catch(Exception ex) { MessageBox.Show(ex.ToString()); }

            // if current profile is removed, then just set to first index
            if (CurrentProfileRemoved)
                Properties.Settings.Default.Last_Selected_Index = 0;

            // otherwise, if current profile still exists...
            else
            {
                int ProfilesRemovedBeforeSelected = 0;

                // updates LSI
                Properties.Settings.Default.Last_Selected_Index -= ProfilesRemovedBeforeSelected;
            }
            // note: only LSI is set here and not dropdown list index b/c thats
            // taken care of in following code:
           
            // reload profiles
            if (mainWindow != null)
                mainWindow.loadProfiles();

            this.Close();
        }

        private bool IsValidProfileName(string newProfileName, ref List<string> currentProfileList)
        {
            // text processing -- condition checking
            // checking length
            if (!(newProfileName.Length > 0 && newProfileName.Length <= 10))
                throw new Exception("Profile names must be 1-10 characters long");

            // filtering out junk
            if (newProfileName.Equals(null))
                throw new Exception("Profile names cannot be empty");

            // checking names
            if (currentProfileList.Contains(newProfileName))
                throw new Exception("Profile with that name already exists");

            return true;
        }

        private void ProfileForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // update dropdown list
        }
    }
}
