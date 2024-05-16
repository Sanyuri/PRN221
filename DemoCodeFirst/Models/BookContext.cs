using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst.Models
{
    internal class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options) 
        { 
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
