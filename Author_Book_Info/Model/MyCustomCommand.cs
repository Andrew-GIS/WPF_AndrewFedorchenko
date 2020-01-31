using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Author_Book_Info.Views
{
    public static class MyCustomCommand
    {
        public static RoutedUICommand ChangeBook { get; set; }
        public static RoutedCommand NewBook { get; set; }
        public static RoutedCommand DelBook { get; set; }
        public static RoutedCommand NewAuthor { get; set; }
        public static RoutedCommand ChangeAuthor { get; set; }
        public static RoutedCommand DelAuthor { get; set; }
        public static RoutedCommand OkAuthor { get; set; }
        public static RoutedCommand OkBook { get; set; }

        static MyCustomCommand()
        {
            MyCustomCommand.ChangeBook = new RoutedUICommand(nameof(ChangeBook), nameof(ChangeBook), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.NewBook = new RoutedUICommand(nameof(NewBook), nameof(NewBook), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.DelBook = new RoutedUICommand(nameof(DelBook), nameof(DelBook), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.NewAuthor = new RoutedUICommand(nameof(NewAuthor), nameof(NewAuthor), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.ChangeAuthor = new RoutedUICommand(nameof(ChangeAuthor), nameof(ChangeAuthor), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.DelAuthor = new RoutedUICommand(nameof(DelAuthor), nameof(DelAuthor), typeof(MainWindow), new InputGestureCollection());
            MyCustomCommand.OkAuthor = new RoutedUICommand(nameof(OkAuthor), nameof(OkAuthor), typeof(NewAuthor), new InputGestureCollection());
            MyCustomCommand.OkBook = new RoutedUICommand(nameof(OkBook), nameof(OkBook), typeof(NewBook), new InputGestureCollection());
        }
    }
}