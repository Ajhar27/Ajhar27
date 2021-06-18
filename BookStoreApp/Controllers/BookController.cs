using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
       public string GetAllBooks()
        {
            return "All Books";
        }

        public string GetBook(int id)
        {
            return $"Book with id = {id}";
        }

        public string SearchBook(string bookName,string authorName)
        {
            return $"hello book Name is {bookName} & Author is Mr. {authorName}";
        }
    }
}
