using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KASHOP.Models;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //production database
            optionsBuilder.UseSqlServer("Server=db39716.public.databaseasp.net; Database=db39716; User Id=db39716; Password=2i%LA3q@6_Jx; Encrypt=True; TrustServerCertificate=True;");

            //developing database
            //optionsBuilder.UseSqlServer("Data Source=.;User ID=SA;Password=Nadoosh131415&;Pooling=False;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Authentication=SqlPassword;Application Name=vscode-mssql;Application Intent=ReadWrite;Command Timeout=30;Database=kashop");
        }
    }
}