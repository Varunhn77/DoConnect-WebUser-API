using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using DoConnectRepository.Data;
using DoConnectRepository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepository.Repositories
{
    public class UserRepository : IUserRepository
    {

        //UsersDb _context;
        //public UserRepository(UsersDb Dbcontext)
        //{
        //    _context = Dbcontext;
        //}

        //public async Task AddUserAsync(User user)
        //{
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //}

        //public List<user> GetAll()
        //{
        //    var list = _context.Users.ToList();
        //        return list;        }

        //public async Task<User> GetUserByUsernameAsync(string username)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        //}

        //public async Task<bool> UserExistsAsync(string username)
        //{
        //    return await _context.Users.AnyAsync(u => u.Username == username);
        //}

        UsersDb _user;
        public UserRepository(UsersDb dbContext)
        {
            _user = dbContext;
        }

        public List<User> GetAll()
        {
            var list = _user.Users.ToList();
            return list;
        }

        //public User getUserByEmail(string Email, string Password)
        //{
        //    return _user.Users.SingleOrDefault(u => u.Email == Email && u.Password==Password);
        //}

        public User Login(string Email, string Password)
        {
            User GetUser = null;
            var result = _user.Users.Where(obj => obj.Email == Email && obj.Password == Password).ToList();
            foreach (var item in result)
                if (result.Count > 0)
                {
                    GetUser = result[0];
                    return GetUser;
                }
            return GetUser;

        }
        //public UserModel GetUserByEmail(UserModel userModel)
        //{
        //    return _dbConnection.UserModels.SingleOrDefault(u => u.Email == userModel.Email);
        //}
        //public User GetUserByEmail(string Email)
        //{
        //    return _user.Users.SingleOrDefault(u => u.Email == Email);

        //    //User userInfo = null;
        //    //var result = _user.Users.Where(obj => obj.Email == Email && obj.Password == Password).ToList();
        //    //foreach (var item in result)
        //    //{
        //    //    userInfo = new User();
        //    //    userInfo.Id = item.Id;
        //    //    userInfo.Username = item.Username;
        //    //    userInfo.Email = item.Email;
        //    //    userInfo.Password = item.Password;

        //    //    //userInfo.Mobile = item.Mobile;
        //    //}
        //    //return userInfo;
        //}


        public void Logout(User user)
        {

            _user.Users.Remove(user);
            _user.SaveChanges();

        }

        public void Register(User user)
        {
            _user.Users.Add(user);
            _user.SaveChanges();
        }
    }
}





//namespace APIDOConnectRepository.Repository
//{
//    public class UserRepository : IUserRepository
//    {
//        UserDbContext _context;
//        public UserRepository(UserDbContext dbcontext)
//        {
//            //getting instance from container and assign to local variable
//            _context = dbcontext;
//        }
//        public User Login(string EmailId, string Password)
//        {
//            User userInfo = null;
//            var result = _context.Users.Where(u => u.EmailId == EmailId && u.Password == Password);
//            foreach (var item in result)
//            {
//                userInfo = new User();
//                userInfo.Id = item.Id;
//                userInfo.FirstName = item.FirstName;
//                userInfo.LastName = item.LastName;
//                userInfo.EmailId = item.EmailId;
//                //userInfo.Mobile = item.Mobile;
//            }
//            return userInfo;
//        }

//        public User Logout(User user)
//        {
//            User Logout1 = null;
//            var result = _context.Users.Where(obj => obj.EmailId == user.EmailId && obj.Password == user.Password).ToList();
//            if (result.Count() > 0)
//            {
//                user = result[0];
//            }
//            return Logout1;
//        }

//        public void Register(User user)
//        {
//            _context.Users.Add(user);
//            _context.SaveChanges();
//        }
//    }
//}

//public UserModel Login(UserModel userModel)
//{
//    // Fetch the user by email
//    var user = _repo.GetUserByEmail(userModel);
//    if (user == null)
//    {
//        return null; // User does not exist
//    }

//    // Verify the password (use hashing in production)
//    if (user.Password != userModel.Password)
//    {
//        return null; // Password mismatch
//    }

//    return user; // Valid user
//}

//UserModel auth = null;
//var result = _dbConnection.UserModels.Where(obj => obj.Email == userModel.Email && obj.Password == userModel.Password).ToList();
//if (result.Count > 0)
//{
//    auth = result[0];
//}
//return auth;
//    }
//    public UserModel GetUserByEmail(UserModel userModel)
//{
//    return _dbConnection.UserModels.SingleOrDefault(u => u.Email == userModel.Email);