using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManager.Models.Entities;

namespace UsersManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToUser> TagToUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = new Guid("10FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Alex",
                    Domain = "first.com"
                },
                new User
                {
                    UserId = new Guid("11FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Sam",
                    Domain = "second.com"
                },
                new User
                {
                    UserId = new Guid("12FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Dmitriy",
                    Domain = "first.com"
                },
                new User
                {
                    UserId = new Guid("13FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Victor",
                    Domain = "second.com"
                },
                new User
                {
                    UserId = new Guid("14FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Azat",
                    Domain = "first.com"
                },
                new User
                {
                    UserId = new Guid("15FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Name = "Arthur",
                    Domain = "second.com"
                }

                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag 
                {
                    TagId = new Guid("10ED2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Value="User"
                },
                new Tag
                {
                    TagId = new Guid("11ED2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Value = "Moderator"
                },
                new Tag
                {
                    TagId = new Guid("12ED2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Value = "NewUser"
                },
                new Tag
                {
                    TagId = new Guid("13ED2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    Value = "RegularUser"
                }

                );

            modelBuilder.Entity<TagToUser>().HasData(
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("10FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("10ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("10FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("12ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("11FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("10ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("11FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("13ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("12FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("10ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("12FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("13ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("13FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("11ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("13FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("13ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("14FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("11ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("14FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("12ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("15FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("10ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                },
                new TagToUser
                {
                    EntityId = Guid.NewGuid(),
                    UserId = new Guid("15FD2873-FF9D-4951-9346-1C71BD0AC0DE"),
                    TagId = new Guid("13ED2873-FF9D-4951-9346-1C71BD0AC0DE")
                }
                );
        }
    }
}
