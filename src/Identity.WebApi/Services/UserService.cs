using Identity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.WebApi.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
    }
    public class UserService: IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { AccountNumber = 316247, Currency = "MU", FullName = "Hamsheed", Username = "hamsheed", Password = "hamsheed123"}
        };

        public bool Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            return true;
        }
    }
}
