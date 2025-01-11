using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountApplication.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser> 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();
            
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<ProductDetail>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(pd => pd.ProductId);

            builder.Entity<ProductDetail>()
                .HasOne(pd => pd.Size)
                .WithMany(s => s.ProductDetails)
                .HasForeignKey(pd => pd.SizeId);
        }
    }
}
