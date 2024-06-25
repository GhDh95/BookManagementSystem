using System.Reflection.Metadata.Ecma335;
using BookManagementSystem.Presentation;

namespace BookManagementSystem.Services;

public class Authentication
{
    private AppContext db; 
    public Authentication(AppContext db)
    {
        this.db = db; 
    }

    public void Login()
    {

        Console.WriteLine("input your username:");
        string un = Console.ReadLine(); 
        Console.WriteLine("input your password:");
        string pw = Console.ReadLine(); 
        User u = new User(un, pw); 
        
        
        var user = db.Users.SingleOrDefault(_u=>_u.Username == u.Username && _u.Password == u.Password);
        if (user != null)
        {
            Console.WriteLine("Login successful");
            SessionUser.User = user;
            if (user.Username == "Admin")
            {
                new AdminUI(); 
            }
            else
            {
                
            }
        }
        else
        {
            Console.WriteLine("does not exist.");
        }

    }

    public bool Logout()
    {
        SessionUser.User = null;
        return true;
    }
}