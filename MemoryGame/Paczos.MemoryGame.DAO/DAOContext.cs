using Microsoft.EntityFrameworkCore;
using Paczos.MemoryGame.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.MemoryGame.DAO
{
    public class DAOContext : DbContext
    {
        public void InitializeData()
        {
            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("MemoGameDB");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MemoryGame;Trusted_Connection=True;");
        }
    }
}
