using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command_Practice28._12
{
    public static class MyCustomCommand
    {
        public static RoutedCommand Show { get; set; }

        static MyCustomCommand()
        {
            MyCustomCommand.Show = new RoutedCommand(nameof(Show), typeof(MainWindow));
        }
    }
}