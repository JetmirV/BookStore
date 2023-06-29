using System;
using System.Collections.Generic;
using Domain.Entities.CartApi;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public partial class CartApiDbContext : DbContext
{
    public CartApiDbContext()
    {
    }

    public CartApiDbContext(DbContextOptions<CartApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<CartItemLog> CartItemLogs { get; set; }

    public virtual DbSet<CartLog> CartLogs { get; set; }

    public virtual DbSet<GeneralLog> GeneralLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BCKLAP-BCHRML3;Database=CartApiDb;User Id=BUCKAROO\\\\\\\\j.veselaj;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC0748DBFDD9");

            entity.ToTable("Cart");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartItem__3214EC0730414E80");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<CartItemLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartItem__3214EC0717A693F6");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<CartLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartLogs__3214EC075B2CD1A0");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<GeneralLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GeneralL__3214EC0774617D17");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.LogData).IsUnicode(false);
            entity.Property(e => e.LogType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
