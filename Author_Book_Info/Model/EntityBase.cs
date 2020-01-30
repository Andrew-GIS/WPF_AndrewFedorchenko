using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author_Book_Info.Model
{
     public class EntityBase
    {
        public int Id { get; set; }

        public bool IsNew { get; set; }

        private static int counter;

        public EntityBase ()
        {
            IsNew = true;
            this.Id = counter++;
        }

        public void Save()
        {
            this.IsNew = false;
        }  
    }
}