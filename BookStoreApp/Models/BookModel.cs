using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class BookModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Title of Book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Author of Book")]
        public string Author { get; set; }

        [StringLength(100,MinimumLength = 5), Display(Name = "Description")]
        [Required]
        public string Property { get; set; }

        [Required]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Choose any Language")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Display(Name ="Total Pages")]
        public int? Totalpage { get; set; }
    }
}
