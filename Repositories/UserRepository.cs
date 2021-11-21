using System.Collections.Generic;
using Shop.Models;

namespace Shop.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            
            users.Add(new User() { Id = 1, Username = "Barry", Password = "Flash", Role = "employee"});
            users.Add(new User() { Id = 2, Username = "Batman", Password = "Bruce", Role = "boss"});

            return users.Find(x => 
                x.Username.ToLower() == username.ToLower() && 
                x.Password.ToLower() == password.ToLower());
        }
    }
}