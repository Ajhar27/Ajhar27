using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Data
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Property { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public int Totalpage { get; set; }

        public string CoverImageURL { get; set; }
        public string PDFURL { get; set; }

        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public Language Language { get; set; }

        public ICollection<BookGallary> BookGallary { get; set; }

    }
}
