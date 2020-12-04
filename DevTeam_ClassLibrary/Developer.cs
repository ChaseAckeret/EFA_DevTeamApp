using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_ClassLibrary
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasPluralsightAccess { get; set; }

        public Developer() { }
        public Developer(string name, int id, bool hasPluralsightAccess)
        {
            Id = id;
            Name = name;
            HasPluralsightAccess = hasPluralsightAccess;
        }
    }
}
