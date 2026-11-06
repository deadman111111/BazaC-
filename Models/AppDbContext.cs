using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

public partial class _43pPotapov2026Context  : DbContext
{
    public _43pPotapov2026Context ()
    {
    }

    public _43pPotapov2026Context (DbContextOptions<_43pPotapov2026Context > options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Stockitem> Stockitems { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=ngknn.ru;Port=5442;Database=43P_Potapov_2026;Username=43P;Password=444444");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategories).HasName("categories_pkey");

            entity.ToTable("categories", "Rabota6");

            entity.Property(e => e.Idcategories).HasColumnName("idcategories");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.HasKey(e => e.Idmanufacture).HasName("manufacture_pkey");

            entity.ToTable("manufacture", "Rabota6");

            entity.Property(e => e.Idmanufacture).HasColumnName("idmanufacture");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorders).HasName("orders_pkey");

            entity.ToTable("orders", "Rabota6");

            entity.Property(e => e.Idorders).HasColumnName("idorders");
            entity.Property(e => e.Dateorder)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateorder");
            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("orders_iduser_fkey");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.Idorderitems).HasName("orderitems_pkey");

            entity.ToTable("orderitems", "Rabota6");

            entity.Property(e => e.Idorderitems).HasColumnName("idorderitems");
            entity.Property(e => e.Idorders).HasColumnName("idorders");
            entity.Property(e => e.Idproducts).HasColumnName("idproducts");
            entity.Property(e => e.Idsize).HasColumnName("idsize");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdordersNavigation).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Idorders)
                .HasConstraintName("orderitems_idorders_fkey");

            entity.HasOne(d => d.IdproductsNavigation).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Idproducts)
                .HasConstraintName("orderitems_idproducts_fkey");

            entity.HasOne(d => d.IdsizeNavigation).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Idsize)
                .HasConstraintName("orderitems_idsize_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproducts).HasName("products_pkey");

            entity.ToTable("products", "Rabota6");

            entity.Property(e => e.Idproducts).HasColumnName("idproducts");
            entity.Property(e => e.Composition)
                .HasMaxLength(200)
                .HasColumnName("composition");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Idcategories).HasColumnName("idcategories");
            entity.Property(e => e.Idmanufacture).HasColumnName("idmanufacture");
            entity.Property(e => e.Idsubcategories).HasColumnName("idsubcategories");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasMaxLength(200)
                .HasColumnName("picture");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdcategoriesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idcategories)
                .HasConstraintName("products_idcategories_fkey");

            entity.HasOne(d => d.IdmanufactureNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idmanufacture)
                .HasConstraintName("products_idmanufacture_fkey");

            entity.HasOne(d => d.IdsubcategoriesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idsubcategories)
                .HasConstraintName("products_idsubcategories_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("role_pkey");

            entity.ToTable("role", "Rabota6");

            entity.Property(e => e.Idrole).HasColumnName("idrole");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Idsize).HasName("size_pkey");

            entity.ToTable("size", "Rabota6");

            entity.Property(e => e.Idsize).HasColumnName("idsize");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Stockitem>(entity =>
        {
            entity.HasKey(e => e.Idstockitems).HasName("stockitems_pkey");

            entity.ToTable("stockitems", "Rabota6");

            entity.Property(e => e.Idstockitems).HasColumnName("idstockitems");
            entity.Property(e => e.Availablequantity).HasColumnName("availablequantity");
            entity.Property(e => e.Idproducts).HasColumnName("idproducts");
            entity.Property(e => e.Idsize).HasColumnName("idsize");

            entity.HasOne(d => d.IdproductsNavigation).WithMany(p => p.Stockitems)
                .HasForeignKey(d => d.Idproducts)
                .HasConstraintName("stockitems_idproducts_fkey");

            entity.HasOne(d => d.IdsizeNavigation).WithMany(p => p.Stockitems)
                .HasForeignKey(d => d.Idsize)
                .HasConstraintName("stockitems_idsize_fkey");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.Idsubcategories).HasName("subcategories_pkey");

            entity.ToTable("subcategories", "Rabota6");

            entity.Property(e => e.Idsubcategories).HasColumnName("idsubcategories");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("users_pkey");

            entity.ToTable("users", "Rabota6");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Idrole).HasColumnName("idrole");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idrole)
                .HasConstraintName("users_idrole_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
