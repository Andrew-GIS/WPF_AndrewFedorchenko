using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Author_Book_Info.Views
{
    /// <summary>
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
        private Book newBook;

        private Book oldBook;

        public NewBook(Book book )
        {
            InitializeComponent();

            this.newBook = new Book();
            this.DataContext = this.newBook;
            this.oldBook = book;
            //this.DataContext = book;

            this.newBook.Title = book.Title;
            this.newBook.Cost = book.Cost;
            this.newBook.Date = book.Date;
            this.newBook.IsNew = book.IsNew;
        }

        private void CancelCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OkBookCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
            this.oldBook.Title = this.newBook.Title;
            this.oldBook.Cost = this.newBook.Cost;
            this.oldBook.Date = this.newBook.Date;
            this.oldBook.IsNew = this.newBook.IsNew;
        }

        private void Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}