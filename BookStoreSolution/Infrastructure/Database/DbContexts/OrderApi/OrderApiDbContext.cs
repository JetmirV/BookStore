﻿using System;
using System.Collections.Generic;
using Domain.Entities.OrderApi;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public partial class OrderApiDbContext : DbContext
{
    public OrderApiDbContext()
    {
    }

    public OrderApiDbContext(DbContextOptions<OrderApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneralLog> GeneralLogs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderItemLog> OrderItemLogs { get; set; }

    public virtual DbSet<OrderLog> OrderLogs { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BCKLAP-BCHRML3;Database=OrderApiDb;User Id=BUCKAROO\\\\\\\\j.veselaj;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneralLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GeneralL__3214EC078D5E974D");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.LogData).IsUnicode(false);
            entity.Property(e => e.LogType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC071B0BA15F");

            entity.ToTable("Order");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC070C9F4837");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<OrderItemLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07C28CAF98");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<OrderLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderLog__3214EC07848912C8");

            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderTyp__3214EC07A2102342");

            entity.ToTable("OrderType");

            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
