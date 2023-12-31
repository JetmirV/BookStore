﻿using Domain.Entities.AccountApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DbContexts.AccountApi;

public partial class AccountApiDbContext : DbContext
{
    public AccountApiDbContext()
    {
    }

    public AccountApiDbContext(DbContextOptions<AccountApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountLog> AccountLogs { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<GeneralLog> GeneralLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC079EB4D018");

            entity.ToTable("Account");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AccountLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountL__3214EC075E366C90");

            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC071C055CC9");

            entity.ToTable("Address");

            entity.Property(e => e.Address1).IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GeneralL__3214EC071593FE18");

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
