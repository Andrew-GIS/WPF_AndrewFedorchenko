using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsManager { get; set; }

        public static int Counter = 0;

        public Employee()
            //int id, string name, string department, DateTime hiredate, bool isManager
        {
            Id = Counter++;
        }
    }
}
