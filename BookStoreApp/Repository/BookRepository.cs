using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{


    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration configuration;

        public BookRepository(BookStoreContext context,IConfiguration _configuration)
        {
            _context = context;
            configuration = _configuration;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreateOn = DateTime.UtcNow,
                Title = model.Title,
                Category = model.Category,
                LanguageId = model.LanguageId,
                Property = model.Property,
                Totalpage = model.Totalpage.HasValue ? model.Totalpage.Value : 0,
                UpdateOn = DateTime.UtcNow,
                CoverImageURL = model.CoverImageURL,
                PDFURL = model.PDFURL
            };

            newBook.BookGallary = new List<BookGallary>();
            foreach (var file in model.Gallary)
            {
                newBook.BookGallary.Add(new BookGallary()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        //public async Task<List<BookModel>> GetAllBooks()
        //{
        //    var books = new List<BookModel>();
        //    var allbooks = await _context.Books.ToListAsync();
        //    if(allbooks?.Any() == true)
        //    {
        //        foreach(var book in allbooks)
        //        {
        //            books.Add(new BookModel()
        //            {
        //                Author = book.Author,
        //                Category = book.Category,
        //                Id = book.Id,
        //                Property = book.Property,
        //                LanguageId = book.LanguageId,
        //                //Language = book.Language.Name,
        //                Title = book.Title,
        //                Totalpage = book.Totalpage,
        //                CoverImageURL = book.CoverImageURL
        //            });
        //        }
        //    }
        //    return books;
        //}
        public async Task<List<BookModel>> GetAllBooks()
        {

            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Id = book.Id,
                Property = book.Property,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Title = book.Title,
                Totalpage = book.Totalpage,
                CoverImageURL = book.CoverImageURL
            }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync()
        {

            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Id = book.Id,
                Property = book.Property,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Title = book.Title,
                Totalpage = book.Totalpage,
                CoverImageURL = book.CoverImageURL
            }).Take(5).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Property = book.Property,
                    Title = book.Title,
                    Totalpage = book.Totalpage,
                    CoverImageURL = book.CoverImageURL,
                    Gallary = book.BookGallary.Select(g => new GallaryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    PDFURL = book.PDFURL
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }
        public string GetAppName()
        {
            return configuration["AppName"]; ;
        }

    }
}
