using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Practice28._12
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsManager { get; set; }

        public static int counter = 1;

        public Employee(int id, string name, string department, DateTime hiredate, bool isManager)
        {
            Id = counter++;
            Name = name;
            Department = department;
            HireDate = hiredate;
            IsManager = isManager;
        }

        public static ObservableCollection<Employee> GiveMeListOfEmploee()
        {
            ObservableCollection<Employee> Empl_list = new ObservableCollection<Employee>
            {
                new Employee(1, "Andrew", "GIS", new DateTime(2015, 7, 20), false),
                new Employee(2, "Ivan", "GIS", new DateTime(2018, 9, 3), true)
            };
            return Empl_list;
        }
    }
}