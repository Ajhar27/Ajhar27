using BookStoreApp.Models;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ViewResult> GetAllBooksAsync()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        [Route("Book-Details/{Id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddBook(bool IsDone = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                Language = "4"
            };

            //we can use dropdown from this type also
            //ViewBag.Language = new SelectList(GetLanguages(),"Id","Text");
            //ViewBag.Language = GetLanguages().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //});
            var grp1 = new SelectListGroup() { Name = "For Indian" };
            var grp2 = new SelectListGroup() { Name = "For NRI" };

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Tamil",Value="1",Group=grp1 },
                new SelectListItem(){Text="Kannad",Value="2",Group=grp1},
                new SelectListItem(){Text="Malyalam",Value="3",Selected=true},
                new SelectListItem(){Text="Urdu",Value="4",Group=grp2},
                new SelectListItem(){Text="China",Value="5",Group=grp2,Disabled=true}
            };
            ViewBag.IsDone = IsDone;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { IsDone = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(GetLanguages(), "Id", "Text");
            return View();
        }

        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, Text = "Hindi" },
                new LanguageModel() { Id = 2, Text = "French" },
                new LanguageModel() { Id = 3, Text = "Marathi" },
                new LanguageModel() { Id = 4, Text = "Punjabi" }
            };
        }
    }
}
