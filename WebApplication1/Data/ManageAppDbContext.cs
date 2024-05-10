using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class ManageAppDbContext:IdentityDbContext<ManageUser>
    {
        public ManageAppDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsRequired(true);
            builder.Entity<ManageUser>().Property(x => x.Id).HasMaxLength(50).IsRequired(true);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


       public DbSet<ManageUser> ManageUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
