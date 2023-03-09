using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdamAsmaca.Models;

public partial class KelimelikDbContext : DbContext
{
    public KelimelikDbContext()
    {
    }

    public KelimelikDbContext(DbContextOptions<KelimelikDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Kelime> Kelimes { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Uye> Uyes { get; set; }

    public virtual DbSet<UyeRol> UyeRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=S102EGT\\SQLEXPRESS;Database=KelimelikDB;User Id=sa;Password=1;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kategori__3213E83FB0E485F0");

            entity.ToTable("Kategori");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad)
                .HasMaxLength(30)
                .HasColumnName("ad");
        });

        modelBuilder.Entity<Kelime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kelime__3213E83FC7E89485");

            entity.ToTable("Kelime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad)
                .HasMaxLength(30)
                .HasColumnName("ad");
            entity.Property(e => e.Kategoriid).HasColumnName("kategoriid");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3213E83F551CC39A");

            entity.ToTable("Rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad)
                .HasMaxLength(10)
                .HasColumnName("ad");
        });

        modelBuilder.Entity<Uye>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Uye__3213E83FB6B62CB8");

            entity.ToTable("Uye");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Sifre)
                .HasMaxLength(10)
                .HasColumnName("sifre");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .HasColumnName("username");
            entity.Property(e => e.Uyeolmatarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uyeolmatarihi");
        });

        modelBuilder.Entity<UyeRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UyeRol__3213E83F6CCC8CEC");

            entity.ToTable("UyeRol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Uyeid).HasColumnName("uyeid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
