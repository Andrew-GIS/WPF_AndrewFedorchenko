using Author_Book_Info.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Author_Book_Info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> bookCollection;

        public ObservableCollection<Author> authorCollection;

        public MainWindow()
        {
            CommandBinding newBookBind = new CommandBinding(MyCustomCommand.NewBook);
            newBookBind.Executed += NewBook_Executed;

            CommandBinding changeBook_bind = new CommandBinding(MyCustomCommand.ChangeBook);
            changeBook_bind.CanExecute += GeneralCommand_CanExecute;
            changeBook_bind.Executed += ChangeBookCommand_Executed;

            CommandBinding delBookBind = new CommandBinding(MyCustomCommand.DelBook);
            delBookBind.CanExecute += GeneralCommand_CanExecute;
            delBookBind.Executed += DeleteBookCommand_Executed;

            CommandBinding newAuthorBind = new CommandBinding(MyCustomCommand.NewAuthor);
            newAuthorBind.Executed += NewAuthor_Executed;

            CommandBinding changeAuthorBind = new CommandBinding(MyCustomCommand.ChangeAuthor);
            changeAuthorBind.CanExecute += GeneralCommand_CanExecute;
            changeAuthorBind.Executed += ChangeAuthorCommand_Executed;

            CommandBinding delAuthorBind = new CommandBinding(MyCustomCommand.DelAuthor);
            delAuthorBind.CanExecute += GeneralCommand_CanExecute;
            delAuthorBind.Executed += DeleteAuthorCommand_Executed;

            this.CommandBindings.Add(newBookBind);
            this.CommandBindings.Add(changeBook_bind);
            this.CommandBindings.Add(delBookBind);

            this.CommandBindings.Add(newAuthorBind);
            this.CommandBindings.Add(changeAuthorBind);
            this.CommandBindings.Add(delAuthorBind);

            InitializeComponent();
            authorCollection = Fabric.GiveAuthorList();
            this.AuthorList.ItemsSource = authorCollection;
        }

        private void NewBook_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //new NewBook { DataContext = this.BookGrid.SelectedItem as Book }.Show();
            //new NewBook { DataContext = new Book() }.Show();
            var newBook = new Book();
            var window = new NewBook(newBook);

            var result = window.ShowDialog();

            if (!result.Value)
            {
                return;
            }
            else
            {
                newBook.Save();
                this.authorCollection[this.AuthorList.SelectedIndex].Books.Add(newBook);
            }
        }

        private void NewAuthor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var newAuthor = new Author();
            var window = new NewAuthor(newAuthor);

            var result = window.ShowDialog();

            if (!result.Value)
            {
                return;
            }
            else
            {
                newAuthor.Save();
                this.authorCollection.Add(newAuthor);
            }
        }

        private void ChangeBookCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //new NewBook { DataContext = this.BookGrid.SelectedItem as Book }.Show();
            //new NewBook(this.BookGrid.SelectedItem as Book).Show();
            var selecBook = BookGrid.SelectedItem as Book;
            
            var window = new NewBook(selecBook);

            var result = window.ShowDialog();

            if (!result.Value)
            {
                return;
            }
            else
            {
                this.BookGrid.Items.Refresh();
            }
        }

        private void ChangeAuthorCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //var  a = this.AuthorList.SelectedItem as Author;
            //a.Save();
            //new NewAuthor(new Author()) { DataContext = this.AuthorList.SelectedItem as Author }.Show();

            if (e.Source is Author)
            {
                var selecAuthor = AuthorList.SelectedItem as Author;

                var window = new NewAuthor(selecAuthor);

                var result = window.ShowDialog();

                if (!result.Value)
                {
                    return;
                }
                else
                {
                    this.AuthorList.Items.Refresh();
                }
            }

            else if (e.Source is Book)
            {
                var selecBook = BookGrid.SelectedItem as Book;

                var window = new NewBook(selecBook);

                var result = window.ShowDialog();

                if (!result.Value)
                {
                    return;
                }
                else
                {
                    this.BookGrid.Items.Refresh();
                }
            }
        }

        private void DeleteBookCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var selectBook = BookGrid.SelectedItem;
            authorCollection[AuthorList.SelectedIndex].Books.Remove(selectBook as Book);
        }

        private void DeleteAuthorCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            authorCollection.Remove(AuthorList.SelectedItem as Author);
        }

        private void GeneralCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (AuthorList.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
