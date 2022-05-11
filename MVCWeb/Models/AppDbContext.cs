using APIPROJECT.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWeb.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
