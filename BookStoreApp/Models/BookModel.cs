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

        public string property { get; set; }
        public string image { get; set; }
        public string category { get; set; }
        public string Language { get; set; }
        public int totalpage { get; set; }
    }
}
