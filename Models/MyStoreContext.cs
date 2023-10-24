using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoDatabaseUsingEntityFramework.Models;

public partial class MyStoreContext : DbContext
{
    public MyStoreContext()
    {
    }

    public MyStoreContext(DbContextOptions<MyStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ACE\\SQLEXPRESS;Database=MyStore;User Id=sa;Password=anhpro123;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2BF606924E");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDDAD2C0C9");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
