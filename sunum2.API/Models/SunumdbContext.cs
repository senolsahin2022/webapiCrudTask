using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sunum2.API.Models;

public partial class SunumdbContext : DbContext
{
    public SunumdbContext()
    {
    }

    public SunumdbContext(DbContextOptions<SunumdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-EL75H5HS\\SQLEXPRESS;database=sunumdb;trusted_connection=true;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductCode).HasColumnName("Product_Code");
            entity.Property(e => e.ProductCreateDate).HasColumnName("Product_Create_Date");
            entity.Property(e => e.ProductImageUrl).HasColumnName("Product_Image_Url");
            entity.Property(e => e.ProductName).HasColumnName("Product_Name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Product_Price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserUserName).HasColumnName("User_UserName");
            entity.Property(e => e.UserUserPassword).HasColumnName("User_UserPassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
