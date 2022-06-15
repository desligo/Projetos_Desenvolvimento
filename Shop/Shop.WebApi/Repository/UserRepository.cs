using Shop.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.WebApi.Repository
{
    public class UserRepository
    {
        public static User GetUser(string username, string password)
        {
            var users = new List<User>()
            {
                new User
                {
                    Id= 1, Username = "Batman", Password = "123"
                },
                new User
                {
                    Id = 2, Username = "Robin", Password = "123"
                }
            };
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
