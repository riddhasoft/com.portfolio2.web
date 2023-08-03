using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using com.portfolio2.web.Models;

namespace com.portfolio2.web.Data
{
    public class comportfolio2webContext : DbContext
    {
        public comportfolio2webContext(DbContextOptions<comportfolio2webContext> options)
            : base(options)
        {
        }

        public DbSet<com.portfolio2.web.Models.UserProfile> UserProfile { get; set; } = default!;

        public DbSet<com.portfolio2.web.Models.Service>? Service { get; set; }

        public DbSet<com.portfolio2.web.Models.Portfolio>? Portfolio { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
