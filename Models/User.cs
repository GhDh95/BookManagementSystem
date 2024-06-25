using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    public int UserId { get; set; }
    private string _username;
    [MaxLength(255)]
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    
    [MaxLength(255)] 
    public string Username
    {
        get => _username;
        set
        {
            IsAdmin = value == "Admin" ? true : false; 
            _username = value; 

        }
    }


    public User()
    {
        IsAdmin = false; 
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        IsAdmin = Username == "Admin" ? true : false; 
    }
}