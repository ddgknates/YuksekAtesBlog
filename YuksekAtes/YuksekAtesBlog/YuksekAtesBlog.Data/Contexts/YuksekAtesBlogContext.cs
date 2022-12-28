using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Data.Entities;

namespace YuksekAtesBlog.Data.Context
{
    public class YuksekAtesBlogContext : DbContext
    {
        public YuksekAtesBlogContext(DbContextOptions<YuksekAtesBlogContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<PostEntity> Posts => Set<PostEntity>();
        public DbSet<AdminEntity> Admins => Set<AdminEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());

            modelBuilder.Entity<AdminEntity>().HasData(new List<AdminEntity>()
                {
                new AdminEntity()
                {
                    Id = 1,
                    Email = "yuksekates@gmail.com",
                    Password = "123456",
                    UserType = "admin"
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
