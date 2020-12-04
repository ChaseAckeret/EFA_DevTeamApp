using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamApplication
{
    public class DeveloperRepo
    {
        private List<Developer> _developers = new List<Developer>();
        private int _id = 1;

        //Create
        public void AddDeveloperToList(string name, bool input)
        {
            Developer developer = new Developer(name, _id, input);

            _developers.Add(developer);

            _id++;

        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _developers;
        }

        //Update
        public bool UpdateExistingDevelopers(int originalId, Developer newDeveloper)
        {
            {
                //Find Developer
                Developer oldDeveloper = GetDeveloperById(originalId);

                //Update Developer
                if(oldDeveloper != null)
                {
                    oldDeveloper.Id = newDeveloper.Id;
                    oldDeveloper.Name = newDeveloper.Name;
                    oldDeveloper.HasPluralsightAccess = newDeveloper.HasPluralsightAccess;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(int id)
        {
            Developer developer = GetDeveloperById(id);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _developers.Count;
            _developers.Remove(developer);

            if(initialCount > _developers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public Developer GetDeveloperById(int id)
        {
            foreach(Developer developer in _developers)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
