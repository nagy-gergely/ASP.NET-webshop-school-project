using musicweb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace musicweb.DataAccessLayer
{
    public class ComicBookDAL : DbContext
    {
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public ComicBookDAL()
        {
            Database.SetInitializer<ComicBookDAL>(new DropCreateDatabaseIfModelChanges<ComicBookDAL>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComicBook>().ToTable("TblComicBook");
            modelBuilder.Entity<ShoppingCart>().ToTable("TblShoppingCart");
            base.OnModelCreating(modelBuilder);
        }
    }
}