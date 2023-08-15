using Infosys.CodeFirstCore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infosys.CodeFirstCore.DataAccessLayer
{

    public class QuickKartDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=QuickKartDBCore1;Integrated Security=true");
            }
        }

        //USING FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            /*
             //Table Category
            //HasAlternateKey to apply unique key constraint & HasName to provide a name to constraint
            modelBuilder.Entity<Category>()
                .HasAlternateKey("CategoryName")
                .HasName("uq_CategoryName");

            //Table Product
            //HasOne() each Product object has one object of type category
            //WithMany each category object has a collection of products
            //HasForeignKey() Categoryid is used as the foreign key column in the entity class product
            //HasConstraintName() provides a name to the foreign key constraint
           modelBuilder.Entity<Product>(entity =>
            {
                entity.HasAlternateKey(e => e.ProductName)
                .HasName("uq_ProductName");

               // entity.Property(e => e.ProductId)
                //.HasColumnType("char(4)");

                entity.HasOne(c => c.Category) //public Category category {get; set;}
                .WithMany(p => p.Products)   // public ICollection<Product> Products {get; set;}
                .HasForeignKey(c => c.CategoryId) //public byte CategoryId {get; set;}
                .HasConstraintName("fh_CategoryId");
            }
            );
            */


        }
    }

}
