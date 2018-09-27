using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AMSApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UserContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}