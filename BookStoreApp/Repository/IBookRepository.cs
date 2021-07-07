using BookStoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync();
        List<BookModel> SearchBook(string title, string author);
    }
}