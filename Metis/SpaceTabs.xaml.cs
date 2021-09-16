using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
namespace Metis
{
    /// <summary>
    /// Interaction logic for SpaceTabs.xaml
    /// </summary>
    public partial class SpaceTabs : UserControl
    {
        // refers to profile name that this spacetab is a part of
        private string parentProfileName {get; set;}
        
        // get/setter property
        public string ParentProfileName
        {
            get => parentProfileName;
            set { parentProfileName = value;  }
        }

        public SpaceTabs()
        {
            InitializeComponent();
        }

        /* Constructor with SpaceName string parameter */
        // constructs a SpaceTabs with text of SpaceName
        public SpaceTabs(string SpaceName) {
            InitializeComponent();
            this.Text = SpaceName; 
            this.Background = Brushes.Aquamarine;
        }

        /* Constructor with SpaceName string and SolidColorBrush brush parameter */
        // constructs a SpaceTabs with text of SpaceName and background of brush
        public SpaceTabs(string SpaceName, SolidColorBrush brush) {
            InitializeComponent();
            this.Text = SpaceName; 
            this.Background = brush;
        }

        /* Context Menu: Rename */
        // renames SpaceTab
        private void RenameSpaceTab(object sender, RoutedEventArgs e) {
            // prompt to rename... replace textblock with textbox
            SpaceName.Visibility = Visibility.Hidden;
            NewSpaceName.Visibility = Visibility.Visible;

            NewSpaceName.KeyUp += DBRenameSpaceTab;
        }

        /* Helper Function : RenameSpaceTab */
        // goes in database, changes name, saves
        private void DBRenameSpaceTab(object sender, KeyEventArgs e)
        {
            // TODO: enable this when user clicks away from box
            if (e.Key != Key.Enter)
                return;

            string currentName = SpaceName.Text.ToString();
            string newName = NewSpaceName.Text.ToString();

            if (currentName == newName)
            {
                // reset visibilities
                SpaceName.Visibility = Visibility.Visible;
                NewSpaceName.Visibility = Visibility.Hidden;
                // unsubscribe from this event
                NewSpaceName.KeyUp -= DBRenameSpaceTab;
                // reset (important b/c binded)
                NewSpaceName.Text = currentName;
                return;
            }

            // database renaming
            string CurrentProfileName = this.ParentProfileName;
            List<SpaceObject> spacesList = MainWindow.JSONtoListOfSpaceObjects(CurrentProfileName);

            // find object in list and change name
            SpacesList currentSpacesList = new SpacesList(spacesList);

            // new name check
            bool validSpaceName = false;
            try
            { validSpaceName = SpaceForm.IsValidSpaceName(newName, ref currentSpacesList); }
            catch (Exception ex) {
                ColorAnimation ErrorFade = new ColorAnimation()
                {
                    From = Brushes.LightSalmon.Color,
                    To = Brushes.LightBlue.Color,
                    Duration = TimeSpan.FromSeconds(0.7),
                };

                Storyboard.SetTarget(ErrorFade, TintOverlay);
                Storyboard.SetTargetProperty(ErrorFade, new PropertyPath("Background.Color"));

                var sb = new Storyboard();
                sb.Children.Add(ErrorFade);

                sb.Begin();
                MessageBox.Show(ex.ToString());
            }

            if (!validSpaceName)
            {
                // reset visibilities
                SpaceName.Visibility = Visibility.Visible;
                NewSpaceName.Visibility = Visibility.Hidden;
                // unsubscribe from this event
                NewSpaceName.KeyUp -= DBRenameSpaceTab;
                // reset (important b/c binded)
                NewSpaceName.Text = currentName;
                return;
            }

            // replacement in spacesList
            foreach (SpaceObject ob in currentSpacesList.GetSpacesList())
            {
                if (ob.SpaceName.Equals(currentName))
                {
                    ob.SpaceName = newName;
                    break;
                }
            }

            // reserialize into database
            // update SQL table with new JSON
            MainWindow.ListOfSpaceObjectstoJSON(ref currentSpacesList, CurrentProfileName); 

            // unsubscribe from this event
            NewSpaceName.KeyUp -= DBRenameSpaceTab;

            // reset visibilities
            SpaceName.Visibility = Visibility.Visible;
            NewSpaceName.Visibility = Visibility.Hidden;
        }

        /* Context Menu: Delete */
        // delete SpaceTab
        private void DeleteSpaceTab(object sender, RoutedEventArgs e)
        {
            // confirm want to delete
            PopupConfirm prompt = new PopupConfirm(
                String.Format("Are you sure you want to delete {0}?", this.Text), 
                String.Format("This data will be lost forever."));
            prompt.SetValue(Grid.ColumnProperty, 0);
            prompt.SetValue(Grid.ColumnSpanProperty, 2);
            prompt.SetValue(Grid.ZIndexProperty, 100);
            prompt.SpaceTabParent = this;

            ((MainWindow)this.Owner).MainGrid.Children.Add(prompt);
            // outsource db stuff... once confirmed in prompt
        }

        /* Helper Function : DeleteSpaceTab */
        // internal so can be called by PopupConfirm
        // called after confirmed from PopupConfirm
        // goes in database & deletes corresponding spacetab
        internal void DBDeleteSpaceTab(object sender, KeyEventArgs e)
        {
            string CurrentProfileName = this.ParentProfileName;
            List<SpaceObject> spacesList = MainWindow.JSONtoListOfSpaceObjects(CurrentProfileName);

            // find object in list and change name
            SpacesList currentSpacesList = new SpacesList(spacesList);
            string CurrentSpaceName = SpaceName.Text.ToString();

            // replacement in spacesList
            foreach (SpaceObject ob in currentSpacesList.GetSpacesList())
            {
                if (ob.SpaceName.Equals(CurrentSpaceName))
                {
                    currentSpacesList.GetSpacesList().Remove(ob);
                    break;
                }
            }

            // reserialize into database
            string newJSON = JsonSerializer.Serialize<SpacesList>(currentSpacesList);

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

        /* Overriding BackgroundProperty */
        // changes dependency property of Space object's background
        public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.Register(
            "Background", 
            typeof(Brush),
            typeof(SpaceTabs),
            // Tells compiler to call OnBackgroundChanged when XAML is changed
            new FrameworkPropertyMetadata(
                null, 
                FrameworkPropertyMetadataOptions.AffectsRender, 
                new PropertyChangedCallback(OnBackgroundChanged)
            )
        );

        /* Change color of Space's background */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Find border in children and change background
            // refer to how Space object is setup... (basically Space's background is border's background)
            foreach (object ob in LogicalTreeHelper.GetChildren(d))
                if (ob is Border) {
                    ((Border)ob).Background = (Brush)e.NewValue;
                    break;
                }
        }

        /* Overriding Background */
        // changes background of border in Space object
        public Brush Background
        {
            get { return (Brush) backgrnd.Background; }
            set { backgrnd.Background = value; }
        }

        /* Overriding  */
        // changes dependency property of Space object's textblock
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            "Text", 
            typeof(String), 
            typeof(SpaceTabs),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnTextChanged)
            )
        );

        /* Change color of Space's Text */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            foreach (object ob in LogicalTreeHelper.GetChildren(d))
                if (ob is Border)
                {
                    ((TextBlock)(((Border)ob).FindName("SpaceName"))).Text = (String)e.NewValue;
                    break;
                }
        }

        /* Overriding Text */
        // changes text of textblock in Space object
        public string Text
        {
            get { return (String) this.SpaceName.Text; }
            set { this.SpaceName.Text = value; }
        }

        /* Gets and sets owner of SpaceTabs */
        public System.Windows.Window Owner { get; set; }

        /* On any SpaceTabs click, do little animation */
        private void SpaceTabs_OnClick(object sender, MouseButtonEventArgs e)
        {
            // animate on click (ie show user click feedback)
            DoubleAnimation animation = new DoubleAnimation(0, 0.7, new Duration(new TimeSpan(2500000)));
            TintOverlay.BeginAnimation(Grid.OpacityProperty, animation);
        }

        /* Defines MouseEnter behavior on SpaceTabs */
        // animates opacity of overlaying tint layer
        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Duration duration = new Duration(new TimeSpan(5000000)); // measured in ticks
            DoubleAnimation animation = new DoubleAnimation(0, 0.7, duration);
            TintOverlay.BeginAnimation(Grid.OpacityProperty, animation);
        }

        /* Defines MouseLeave behavior on SpaceTabs */
        // animates opacity of overlaying tint layer
        private void MouseLeave(object sender, MouseEventArgs e)
        {
            Duration duration = new Duration(new TimeSpan(5000000));
            DoubleAnimation animation = new DoubleAnimation(0.7, 0, duration);
            TintOverlay.BeginAnimation(Grid.OpacityProperty, animation);
        }

        private void ChangeIcon(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("TODO: make a flyout that allows selection of different emojis");
        }
    }
}
