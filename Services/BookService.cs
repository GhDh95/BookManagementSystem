using System.Globalization;
using CsvHelper;

namespace BookManagementSystem.Services;

public class BookService
{
    private readonly AppContext db; 
    public BookService(AppContext db)
    {
        this.db = db; 
    }
    public void AddBook(Book book)
    {
        db.Add(book);
        db.SaveChanges(); 
    }

    public IEnumerable<Book> GetBooks()
    {
        var books = db.Books;
        return books;
    }

    public void addBooks()
    {
        var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };
        var editedBooks = new List<Book>();
        using (var reader = new StreamReader("C:\\Users\\GhassenDhaoui\\RiderProjects\\BookManagementSystem\\Data\\Marvel_Comics.csv")) 
        {
            using (var csv = new CsvReader(reader, config))
            {
                var initialBooks  = csv.GetRecords<Comic>().ToList();
                foreach (var book in initialBooks)
                {
                    if (book.PublishDate == null || book.PublishDate == "none")
                    {
                        continue;
                    }
                    else
                    {
                        if (DateTime.TryParse(book.PublishDate, out DateTime d))
                        {
                            editedBooks.Add(new Book
                            {
                                PublishDate = d,
                                Price = book.Price,
                                ComicName = book.ComicName,
                                Rating = book.Rating
                            
                            });        
                        }
                        else
                        {
                            editedBooks.Add(new Book
                            {
                                PublishDate = DateTime.MaxValue,
                                Price = book.Price,
                                ComicName = book.ComicName,
                                Rating = book.Rating
                            
                            });
                        }
                        
                        
                    }
                }
        
                
                using (db)
                {
                    if (db.Books.Count() < 100)
                    {
                        db.Books.AddRange(editedBooks);
                        db.SaveChanges();
                        
                    }
                }
        
            }
        }

    }
    
    
}