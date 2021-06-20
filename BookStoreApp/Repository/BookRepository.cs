using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSaurce();
        }

        public BookModel GetBookById(int id)
        {
            return DataSaurce().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel>SearchBook(string title,string author)
        {
            return DataSaurce().Where(x => x.Title.Contains(title)|| x.Author.Contains(author)).ToList(); 
        }

        private List<BookModel> DataSaurce()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Ajhar"},
                new BookModel(){Id=2, Title="C#", Author="AKJain"},
                new BookModel(){Id=3, Title="Java", Author="RK"},
                new BookModel(){Id=4, Title="Dot Net", Author="DK"},
                new BookModel(){Id=5, Title="Math", Author="PK"},
                new BookModel(){Id=6, Title="English", Author="Kamal"},
                new BookModel(){Id=7, Title="MVC Core", Author="Sumit"}
            };
        }
    }
}
