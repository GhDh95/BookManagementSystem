using BookManagementSystem.Services;

namespace BookManagementSystem.Presentation;

public class AdminUI
{
    public AdminUI()
    {
        Console.WriteLine("1: add books.");
        Console.WriteLine("2: list all books.");
        string i = Console.ReadLine();
        if (int.TryParse(i, out int num))
        {
            var db = new AppContext();
            var bService = new BookService(db); 
            switch (num)
            {
                case 1:
                    bService.addBooks();
                    break;
                case 2:
                    var books = bService.GetBooks();
                    foreach (var book in books)
                    {
                        Console.WriteLine($"book name: {book.ComicName}, book price: {book.Price}, book Rating: {book.Rating}, book date: {book.PublishDate}");
                    }

                    break; 
            }
        }
        else
        {
            Console.WriteLine("invalid input");
        }
    }
}