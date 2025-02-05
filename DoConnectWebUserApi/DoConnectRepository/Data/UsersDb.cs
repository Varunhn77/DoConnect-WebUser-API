using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectEntity;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepository.Data
{
    public class UsersDb : DbContext
    {
        public UsersDb(DbContextOptions<UsersDb> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
