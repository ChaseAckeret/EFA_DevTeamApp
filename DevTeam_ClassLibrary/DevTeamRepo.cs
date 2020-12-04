using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_ClassLibrary
{
    public class DevTeamRepo
    {
        private List<DevTeam> _devTeam = new List<DevTeam>();
        private int _id = 1;

        //Create
        public void AddTeamToList(DevTeam team)
        {
            _devTeam.Add(team);
            team.TeamId = _id;
            _id++;
        }
        //Read
        public List<DevTeam> GetTeamList()
        {
            return _devTeam;
        }
        //Update
        public bool UpdateExistingTeam(int originalId, DevTeam newTeam)
        {
            {
                //Find Team
                DevTeam oldTeam = GetTeamById(originalId);

                //Update Team
                if (oldTeam != null)
                {
                    oldTeam.TeamId = newTeam.TeamId;
                    oldTeam.TeamName = newTeam.TeamName;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Delete
        public bool RemoveTeamFromList(int id)
        {
            DevTeam developer = GetTeamById(id);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _devTeam.Count;
            _devTeam.Remove(developer);

            if (initialCount > _devTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public DevTeam GetTeamById(int id)
        {
            foreach (DevTeam team in _devTeam)
            {
                if (team.TeamId == id)
                {
                    return team ;
                }
            }
            return null;
        }
    }
}