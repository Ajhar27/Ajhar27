using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }

        public DbSet<BookGallary> BookGallary { get; set; }

        //we create connectionStr in Startup.cs file so no need to create here
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;")
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
