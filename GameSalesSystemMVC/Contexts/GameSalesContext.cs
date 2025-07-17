using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Contexts
{
    public class GameSalesContext : DbContext
    {
        public GameSalesContext() : base("name=GameSalesMVCConnection")
        {

        }
        
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartGame> CartGames { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseGame> PurchaseGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //        modelBuilder.Entity<User>()
            //.HasRequired(a => a.Cart)
            //.WithMany()
            //.HasForeignKey(a => a.CartId);
            modelBuilder.Entity<User>()
            .HasOptional(s => s.Cart) // Mark Address property optional in Student entity
             .WithRequired(ad => ad.User); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
            modelBuilder.Properties<string>()
            .Configure(s => s.HasMaxLength(200).HasColumnType("varchar"));
            base.OnModelCreating(modelBuilder);
        }


    }
    
}