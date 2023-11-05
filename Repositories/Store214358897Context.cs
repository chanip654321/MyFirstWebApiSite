using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;
namespace Entities;

public partial class Store214358897Context : DbContext
{
    public Store214358897Context()
    {
    }

    public Store214358897Context(DbContextOptions<Store214358897Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriesTbl> CategoriesTbls { get; set; }

    public virtual DbSet<OrderItemTbl> OrderItemTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=Store_214358897;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriesTbl>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B86901074");

            entity.ToTable("Categories_tbl");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OrderItemTbl>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681560F6FBB");

            entity.ToTable("OrderItem_tbl");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_OrderItemTbl_OrderId");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_OrderItemTbl_ProductId");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders_t__C3905BCFE0865784");

            entity.ToTable("Orders_tbl");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.User).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_orderTbl_UserId");
        });

        modelBuilder.Entity<ProductsTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD50DBE4B3");

            entity.ToTable("Products_tbl");

            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsTbls)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_tbl_Categories_tbl");
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users_tb__1788CC4C6861546A");

            entity.ToTable("Users_tbl");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
