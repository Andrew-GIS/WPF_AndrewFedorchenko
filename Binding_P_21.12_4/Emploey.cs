using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_P_21._12_4
{
    public class Emploey
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMaster { get; set; }

        public Emploey(string firstName, string lastName, bool isMaster)
        {
            FirstName = firstName;
            LastName = lastName;
            IsMaster = isMaster;
        }
    }
}