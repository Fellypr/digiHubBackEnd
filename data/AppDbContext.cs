using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.model;
using Microsoft.EntityFrameworkCore;
namespace BackEnd.data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}