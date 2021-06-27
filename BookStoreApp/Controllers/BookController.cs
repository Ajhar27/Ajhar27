using BookStoreApp.Models;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
       public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();

            return View(data); 
        }

        [Route("Book-Details/{Id}",Name ="bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBook(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddBook(bool IsDone = false,int bookId= 0)
        {
            ViewBag.IsDone = IsDone;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            int id =_bookRepository.AddNewBook(bookModel);

            if (id > 0)
            {
                return RedirectToAction(nameof(AddBook),new { IsDone = true, bookId = id});
            }
            return View();
        }
    }
}
