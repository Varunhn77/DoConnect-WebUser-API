using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;

namespace DoConnectRepository.Repositories
{
    public interface IUserRepository
    {
        //Task<User> GetUserByUsernameAsync(string username);
        //Task AddUserAsync(User user);
        //Task<bool> UserExistsAsync(string username);
        void Register(User user);

        User Login(string Email, string Password);

        void Logout(User user);

       // User getUserByEmail(string Email, string Password);


        List<User> GetAll();

    }
}
