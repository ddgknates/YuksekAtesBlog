using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuksekAtesBlog.Data.Context
{
    public class YuksekAtesBlogContextFactory : IDesignTimeDbContextFactory<YuksekAtesBlogContext>
    {
        public YuksekAtesBlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YuksekAtesBlogContext>();

            optionsBuilder.UseSqlServer("server=DESKTOP-EAFIFF0\\SQLEXPRESS;database=YuksekAtesBlog; Trusted_Connection=true");

            return new YuksekAtesBlogContext(optionsBuilder.Options);
        }
    }
}
