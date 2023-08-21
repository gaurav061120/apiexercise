using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models;

public partial class ProductsDbContext : DbContext
{
    public ProductsDbContext()
    {
    }

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }

    public virtual DbSet<CompanysInfo> CompanysInfos { get; set; }

    public virtual DbSet<ProductsInfo> ProductsInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MFEN465;database=ProductsDb;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__CompanyI__C1F8DC39646FAFEA");

            entity.ToTable("CompanyInfo");

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("CId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CName");
        });

        modelBuilder.Entity<CompanysInfo>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Companys__C1F8DC392A18416C");

            entity.ToTable("CompanysInfo");

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("CId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CName");
        });

        modelBuilder.Entity<ProductsInfo>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Products__C5775540CDAB862D");

            entity.ToTable("ProductsInfo");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PId");
            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.Pmdate)
                .HasColumnType("date")
                .HasColumnName("PMdate");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.Pprice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PPrice");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.ProductsInfos)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__ProductsInf__CId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
