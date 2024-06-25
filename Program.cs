//book management system
//login and resigration
//functionality for user and for admin
//for admin: 
//add, update, delete book
//list all books 
//search book by title, author, genre...

//for users
//borrow book
//return book
//view borrowing history
//search for books by criteria : title, author, genre ISBN

using System.Globalization;
using BookManagementSystem;
using BookManagementSystem.Services;
using CsvHelper;
using CsvHelper.Configuration;
using SQLitePCL;
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
            break; 
        
    }    
}
else
{
    Console.WriteLine("choose a valid number");
}

