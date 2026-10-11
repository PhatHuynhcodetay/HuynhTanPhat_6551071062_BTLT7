using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cau1_QuanLyTheLoaiSach.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ThucHanh_EFCore_Chuong8;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaTl).HasName("PK__TheLoaiS__272500718931AE90");

            entity.ToTable("TheLoaiSach");

            entity.HasIndex(e => e.TenTheLoai, "UQ__TheLoaiS__327F958F9EABA0A7").IsUnique();

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuongSach).HasDefaultValue(0);
            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
