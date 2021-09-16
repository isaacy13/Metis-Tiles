using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Metis
{
    // This class is used to create JSON when creating a space (refer to SpaceForm)
    public class SpaceObject
    {
        // variables
        private string spaceName { get; set; } // TODO: in future, to improve lookup times, have spaceName be a column in DB
                                               // pros: faster spaceName lookup (O(log n) as opposed to O(n)), more space for tasks for each space
                                               // cons: increased space usage
        
        private ObservableCollection<TaskInfo> spaceData { get; set; } // holds a list of (taskName, dueDate, & notes)

        public string SpaceName { 
            get => spaceName;
            set { spaceName = value; }
        }
        public ObservableCollection<TaskInfo> SpaceData { 
            get => spaceData;
            set { spaceData = value;  }
        }

        // constructors
        public SpaceObject()
        {
            spaceName = "NULL";
            spaceData = null;
        }

        public SpaceObject(string name, ObservableCollection<TaskInfo> info) 
        { 
            spaceName = name;
            spaceData = info;
        }
    }
}
