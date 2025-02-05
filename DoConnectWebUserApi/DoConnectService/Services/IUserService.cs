using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;

namespace DoConnectService.Services
{
    public interface IUserService
    {
        //Task<User> RegisterUserAsync(User user);
        //Task<User> LoginUserAsync(string username, string password);
        //Task LogoutUserAsync();
        //void Register(User user);


        void Register(User user);
        User Login(string Email, string Password);

        void Logout(User user);

        //User getUserByEmail(string Email, string Password);

        List<User> GetUser();

    }
}
