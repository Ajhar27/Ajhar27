using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Property { get; set; }
        
        public string Category { get; set; }
        public string Language { get; set; }
        public int Totalpage { get; set; }
    }
}
