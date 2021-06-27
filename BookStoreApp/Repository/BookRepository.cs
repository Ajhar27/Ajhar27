using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{

    
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreateOn = DateTime.UtcNow,
                Title = model.Title,
                Category = model.Category,
                Language = model.Language,
                Property = model.Property,
                Totalpage = model.Totalpage,
                UpdateOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Id = book.Id,
                        Property = book.Property,
                        Language = book.Language,
                        Title = book.Title,
                        Totalpage = book.Totalpage
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookdetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Id = book.Id,
                    Language = book.Language,
                    Property = book.Property,
                    Title = book.Title,
                    Totalpage = book.Totalpage
                };
                return bookdetails;
            }
            return null;
            
            //return DataSaurce().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel>SearchBook(string title,string author)
        {
            return DataSaurce().Where(x => x.Title.Contains(title)|| x.Author.Contains(author)).ToList(); 
        }

        private List<BookModel> DataSaurce()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Ajhar",Property="This book is about MVC",Category="MVC Programming",Language="English",Totalpage=560},
               
            };
        }
    }
}
