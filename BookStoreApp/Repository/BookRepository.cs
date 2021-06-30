﻿using BookStoreApp.Data;
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
                LanguageId = model.LanguageId,
                Property = model.Property,
                Totalpage = model.Totalpage.HasValue ? model.Totalpage.Value : 0,
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
                        LanguageId = book.LanguageId,
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
                    LanguageId = book.LanguageId,
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
            return null;
        }

    }
}
