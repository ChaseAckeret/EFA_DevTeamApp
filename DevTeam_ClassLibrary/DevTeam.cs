using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_ClassLibrary
{
    public class DevTeam
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<Developer> Developer { get; set; } = new List<Developer>();

        public DevTeam() { }
        public DevTeam(int teamId, 
                       string teamName, 
                       List<Developer> developer)
        {
            TeamId = teamId;
            TeamName = teamName;
            Developer = developer;
        }
    }
}
