using System;
using System.Collections.Generic;
using Domain.Entities.BookStore;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public partial class BookStoreApiDbContext : DbContext
{
    public BookStoreApiDbContext()
    {
    }

    public BookStoreApiDbContext(DbContextOptions<BookStoreApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<GeneralLog> GeneralLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BCKLAP-BCHRML3;Database=BookStoreApiDb;User Id=BUCKAROO\\\\\\\\j.veselaj;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC070104F6C4");

            entity.Property(e => e.Authors)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Picture).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<GeneralLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GeneralL__3214EC07ACD9229E");

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
