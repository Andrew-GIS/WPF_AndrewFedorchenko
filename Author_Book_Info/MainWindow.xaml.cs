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
            newBookBind.Executed += NewCommand_Executed;

            CommandBinding changeBook_bind = new CommandBinding(MyCustomCommand.ChangeBook);
            changeBook_bind.CanExecute += GeneralCommand_CanExecute;
            changeBook_bind.Executed += ChangeCommand_Executed;

            CommandBinding delBookBind = new CommandBinding(MyCustomCommand.DelBook);
            delBookBind.CanExecute += GeneralCommand_CanExecute;
            delBookBind.Executed += DeleteCommand_Executed;

            CommandBinding newAuthorBind = new CommandBinding(MyCustomCommand.NewAuthor);
            newAuthorBind.Executed += NewCommand_Executed;

            CommandBinding changeAuthorBind = new CommandBinding(MyCustomCommand.ChangeAuthor);
            changeAuthorBind.CanExecute += GeneralCommand_CanExecute;
            changeAuthorBind.Executed += ChangeCommand_Executed;

            CommandBinding delAuthorBind = new CommandBinding(MyCustomCommand.DelAuthor);
            delAuthorBind.CanExecute += GeneralCommand_CanExecute;
            delAuthorBind.Executed += DeleteCommand_Executed;

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

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            var newAuthor = new Author();
            var Authorwindow = new NewAuthor(newAuthor);

            var newBook = new Book();
            var Bookwindow = new NewBook(newBook);

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            if (source == "newAuthorButton" || source == "listBoxItem" || source == "myNewAuthorMenuItem")
            {
                var Authorresult = Authorwindow.ShowDialog();
                if (!Authorresult.Value)
                {
                    return;
                }
                else
                {
                    newAuthor.Save();
                    this.authorCollection.Add(newAuthor);
                }
            }

            else if (source == "newBookButton" || source == "dataGridItem" || source == "myNewBookMenuItem")
            {
                var Bookresult = Bookwindow.ShowDialog();
                if (!Bookresult.Value)
                {
                    return;
                }
                else
                {
                    newBook.Save();
                    this.authorCollection[this.AuthorList.SelectedIndex].Books.Add(newBook);
                }
            }
        }

        private void ChangeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name.ToString();
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            if (source == "changeAuthorButton" || source == "listBoxItem" || source == "myEditMenuItem")
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

            else if (source == "changeBookButton" || source == "dataGridItem" || source == "myEditMenuItem")
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

        public void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            if (source == "deleteAuthorButton" || source == "listBoxItem" || source == "myDeleteAuhtorMenuItem")
            {
                authorCollection.Remove(AuthorList.SelectedItem as Author);
            }
            else if (source == "deleteBookButton" || source == "dataGridItem" || source == "myDeleteBookMenuItem")
            {
                var selectBook = BookGrid.SelectedItem;
                authorCollection[AuthorList.SelectedIndex].Books.Remove(selectBook as Book);
            }
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