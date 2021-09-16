using System;
using System.Windows;

using System.Data;
using System.Data.SqlClient;

using System.Text.Json;

namespace Metis
{
    public partial class SpaceForm : Window
    {
        public SpaceForm()
        {
            InitializeComponent();
        }

        /* Adds a Space object's information to database */
        private void addSpace(object sender, RoutedEventArgs e)
        {
            // adds form information and puts it into database
            string query = "SELECT * FROM [data];";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection_String)) 
            {
                // fill datatable
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);

                    /* TESTING USER INPUT */

                    // set primary key column (to use .Find method later)
                    DataColumn[] keyColumns = new DataColumn[1];
                    keyColumns[0] = dataTable.Columns["profileName"];
                    dataTable.PrimaryKey = keyColumns;


                    /* via profile dropdown, the last_selected_key should change accordingly.
                     :: find current row, get current data, & deserialize */
                    MainWindow mainWindow = Owner as MainWindow;
                    string name = mainWindow.ProfileDropDownList.Items.GetItemAt(Properties.Settings.Default.Last_Selected_Index).ToString();
                    DataRow currentRow = dataTable.Rows.Find(name);
                    string currJSONData = currentRow.Field<string>("spacesJSON");

                    // grab list of current spaces
                    SpacesList currentSpacesList;
                    if (currJSONData.Length > 0) // if list not empty
                        currentSpacesList = JsonSerializer.Deserialize<SpacesList>(currJSONData);
                    else // if empty list
                        currentSpacesList = new SpacesList();

                    // testing user's inputted space name
                    bool validSpaceName = false;
                    string newSpaceNameString = newSpaceName.Text.Trim(' '); // trims off whitespace
                    try
                    { validSpaceName = IsValidSpaceName(newSpaceNameString, ref currentSpacesList); }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    /* once all fields are verified to work add to database and load into application */
                    if (validSpaceName)
                    {
                        // create a new space based on given name
                        SpaceObject currentSpaceObject = new SpaceObject(newSpaceNameString, null);

                        // add new data & reserialize
                        currentSpacesList.AddToSpacesList(currentSpaceObject);

                        string newJSON = JsonSerializer.Serialize<SpacesList>(currentSpacesList);

                        // update SQL table with new JSON
                        connection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("UPDATE data SET spacesJSON = @newJSON WHERE profileName = @pn", connection))
                        {
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@newJSON";
                            param.Value = newJSON;

                            sqlCommand.Parameters.Add(param);

                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@pn";
                            param2.Value = currentRow["profileName"];

                            sqlCommand.Parameters.Add(param2);

                            sqlCommand.ExecuteReader();
                        }

                        mainWindow.loadSpaces();
                        ((MainWindow)this.Owner).CurrentSpaceTab = newSpaceNameString; // updates current spacetab view via binding... refer to mainwindow
                    }
                }
            }

            this.Close();
        }

        public static bool IsValidSpaceName(string newSpaceName, ref SpacesList currentSpaceList)
        {
            // text processing -- condition checking
            // checking length
            if (!(newSpaceName.Length > 0 && newSpaceName.Length <= 10))
                throw new Exception("Space names must be 1-10 characters long");

            // filtering out junk
            if (newSpaceName.Equals(null))
                throw new Exception("Space names cannot be empty");

            // checking names
            if (currentSpaceList.Contains(newSpaceName))
                throw new Exception("Space with that name already exists");
            
            return true;
        }
    }
}
