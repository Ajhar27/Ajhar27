using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookStoreApp.Models
{
    public class BookModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Title of Book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Author of Book"), StringLength(50, MinimumLength = 5)]
        public string Author { get; set; }

        [StringLength(100,MinimumLength = 5), Display(Name = "Book Description")]
        [Required]
        public string Property { get; set; }

        [Required]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Choose any Language")]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        
        public string Language { get; set; }

        [Display(Name ="Total Pages")]
        public int? Totalpage { get; set; }

        [Display(Name = "Choose cover photo of the book")]
        [Required(ErrorMessage = "Please Choose any photo of book")]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageURL { get; set; }

        [Display(Name = "Choose cover photo of the book")]
        [Required(ErrorMessage = "Please Choose any photo of book")]
        public IFormFileCollection GallaryImages { get; set; }
        public List<GallaryModel> Gallary { get;  set; }


    }
}
