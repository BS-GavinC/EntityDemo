using EntityDemo.configs;
using EntityDemo.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo.context
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TP1828I\\SQLEXPRESS;Database=entity;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            });

            using (DataContext db = new DataContext())
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = Guid.NewGuid(),
                    Email = "pomme@pot.be",
                    UserRole = db.roles.Where(x => x.Name == "Admin").FirstOrDefault()
                });
            }
        }
    }
}
