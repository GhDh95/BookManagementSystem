using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem;

public class Book
{
    public int BookId { get; set; }
    public string ComicName { get; set; }
    public DateTime PublishDate { get; set; }
    public string Rating { get; set; }
    public string Price { get; set; }

    
}