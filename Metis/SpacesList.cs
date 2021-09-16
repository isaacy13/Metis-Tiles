using System.Collections.Generic;

namespace Metis
{
    public class SpacesList
    {
        public List<SpaceObject> ListOfSpaces { get; set; }

        public SpacesList()
        {
            ListOfSpaces = new List<SpaceObject>(0);
        }

        public SpacesList(List<SpaceObject> other)
        {
            this.ListOfSpaces = other;
        }

        public List<SpaceObject> GetSpacesList() { return ListOfSpaces; }
        public bool Contains(string SpaceName)
        {
            foreach (SpaceObject so in ListOfSpaces)
                if (SpaceName.Equals(so.SpaceName))
                    return true;
            return false;
        }

        public void AddToSpacesList(SpaceObject other){ ListOfSpaces.Add(other); }
    }
}
