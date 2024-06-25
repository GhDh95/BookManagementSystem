using BookManagementSystem;
using BookManagementSystem.Services;
using AppContext = BookManagementSystem.AppContext;

var db = new AppContext();

var admin = db.Users.SingleOrDefault(u => u.Username == "Admin");
if (admin == null)
{
    db.Users.Add(new User() {Username = "Admin", Password = "1995"});
    db.SaveChanges(); 
}



Console.WriteLine("1: login");
Console.WriteLine("2: register");


string a = Console.ReadLine();

if (int.TryParse(a, out int number))
{
    switch (number)
    {
        case 1:
            Authentication auth = new Authentication(db);
            auth.Login();
            break;
        case 2: 
            Console.WriteLine("registered");
            Console.WriteLine("Not yet implemented");
            break; 
        
    }    
}
else
{
    Console.WriteLine("choose a valid number");
}

