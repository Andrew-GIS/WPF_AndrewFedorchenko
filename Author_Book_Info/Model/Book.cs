using Author_Book_Info.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author_Book_Info
{
    public class Book: EntityBase
    {
        public string Title { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
    }
}
