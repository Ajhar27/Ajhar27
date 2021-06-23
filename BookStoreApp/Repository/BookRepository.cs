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
                new BookModel(){Id=1, Title="MVC", Author="Ajhar",property="This book is about MVC",category="MVC Programming",Language="English",totalpage=560},
                new BookModel(){Id=2, Title="C#", Author="Madhav" ,property="This book is about C#",category="C# Logic",Language="German",totalpage=1562},
                new BookModel(){Id=3, Title="Java", Author="Anshul",property="This book is about Java",category="Core java concept",Language="Spanish",totalpage=1860},
                new BookModel(){Id=4, Title="Dot Net Core", Author="Rajeev",property="This book is about Dot net",category="Foundation of Dot Net",Language="Bangali",totalpage=960},
                new BookModel(){Id=5, Title="F#", Author="Kamal",property="This book is about F#",category="Basics Of F#",Language="Hindi",totalpage=260},
                new BookModel(){Id=6, Title="Python", Author="Kunal",property="This book is about Python",category="New Learning of Python",Language="Urdu",totalpage=160},
                
            };
        }
    }
}
