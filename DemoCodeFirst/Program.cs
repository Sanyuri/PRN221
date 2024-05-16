using DemoCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
             .UseSqlServer("server=HERNIEL;user=Herniel;password=Sanyuri1805;database=DemoCodeFirst")
             .Options;
        using var db = new BookContext(options);
        db.Database.EnsureCreated();
        ////create data for dtb
        //Author author = new Author { Name = "Author 1", Books = new List<Book>
        //    {
        //        new Book { Title = "Book 1" , PublishYear = 2000},
        //        new Book { Title = "Book 2" , PublishYear = 2010},
        //    }
        //};
        //db.Author.Add(author);
        //db.SaveChanges();

        ////Delete data from dtb
        //Author author = db.Author.FirstOrDefault(a => a.Name.Equals("Author 1"));
        //db.Author.Remove(author);
        //db.SaveChanges();

        ////update data from dtb
        //Book bookInDb = db.Books.FirstOrDefault(b => b.Id == 3);
        //bookInDb.Title = "New Title";
        //db.Books.Update(bookInDb);
        //db.SaveChanges();

        //read data from dtb
        foreach (var authordb in db.Author.Include(b => b.Books))
        {
            Console.WriteLine($"{authordb} wrote...");

            foreach(var book in authordb.Books)
            {
                Console.WriteLine($"    {book}");
            }
            Console.WriteLine();
        }
    }
}