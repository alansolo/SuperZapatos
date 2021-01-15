using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace BD_SuperZapatos.Models
{
    public class DbContextSuperZapatos: DbContext
    {
        private string GlobalConnectionString;
        public DbContextSuperZapatos(string connectionString)
        {
            GlobalConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Comandos
            //dotnet tool install --global dotnet-ef
            //dotnet ef migrations add Migrations --project BD_SuperZapatos
            //dotnet ef database update --project BD_SuperZapatos

            //Migrations
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-M949GPQ\\SQLEXPRESS; Initial Catalog=SuperZapatos; User Id=sa; Password=2005310943;");           

            //Dev
            optionsBuilder.UseSqlServer(GlobalConnectionString);
        }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Stores> Stores { get; set; }
    }
}

