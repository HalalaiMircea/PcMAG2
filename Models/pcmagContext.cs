﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PcMAG2.Models
{
    public partial class PcmagContext : DbContext
    {
        public PcmagContext()
        {
        }

        public PcmagContext(DbContextOptions<PcmagContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=./Pcmag.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProductId });

                entity.ToTable("CART_ITEM");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(2000)")
                    .HasColumnName("description");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnType("varchar(2083)")
                    .HasColumnName("image_url");

                entity.Property(e => e.Price)
                    .HasColumnType("float(9,2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("PRODUCT_CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
