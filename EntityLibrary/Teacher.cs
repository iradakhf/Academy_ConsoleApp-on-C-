using EntityLibrary;
using EntityLibrary.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibarary
{
    public class Teacher : Person, IEntity
    {
        public List<Group> Groups { get; set; }

        public Teacher()
        {
            Groups = new List<Group>();
        }
        public int Id { get ; set ; }
    }
}
