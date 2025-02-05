using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using DoConnectRepository.Data;
using DoConnectRepository.Repositories;
//using Microsoft.AspNetCore.Identity;



namespace DoConnectService.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repo;
        public UserService(IUserRepository userRepository)
        {
            _repo = userRepository;
        }

        public List<User> GetUser()
        {
            return _repo.GetAll();
        }

        public void Register(User user)
        {
            _repo.Register(user);
        }

        public User Login(string Email, string Password)
        {
            // Fetch the user by email
            var use = _repo.Login(Email, Password);

            return use; // Valid user
        }

        public void Logout(User user)
        {
            _repo.Logout(user);
        }

        //public User getUserByEmail(string Email, string Password)
        //{
        //    throw new NotImplementedException();
        //}




        // IUserRepository _userRepository;
        // private readonly IPasswordHasher<User> _passwordHasher;

        // public UserService(IUserRepository userRepository)  //IPasswordHasher<User> passwordHasher
        // {
        //     _userRepository = userRepository;
        //    // _passwordHasher = passwordHasher;
        // }
        // public  List<User> GetUser()
        // {
        //     return _userRepository.GetAll();
        // }

        // public async Task<User> LoginUserAsync(string username, string password)
        // {
        //     var ser = await _userRepository.GetUserByUsernameAsync(username);
        //     return ser;
        //     //if (ser == null) 
        //     //    return null;

        //    // var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        //    // return verificationResult == PasswordVerificationResult.Success ? user : null;
        // }

        // public async Task LogoutUserAsync()
        // {
        //     // Implement logout logic if using cookies or JWT
        //     await Task.CompletedTask;
        // }

        // public async Task<bool> RegisterUserAsync(string username, string email, string password)
        // {
        //     if (await _userRepository.UserExistsAsync(username))
        //         return false;

        //     var user = new User
        //     {
        //         Username = username,
        //         Email = email,
        //        // PasswordHash = _passwordHasher.HashPassword(null, password)
        //     };

        //     await _userRepository.AddUserAsync(user);
        //     return true;
        // }
    }
}

