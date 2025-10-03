using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using User_1.Domain.Entities;

namespace User_1.Infrastructure.Context;

public partial class ContextFile : DbContext
{
    public ContextFile()
    {
    }

    public ContextFile(DbContextOptions<ContextFile> options)
        : base(options)
    {
    }

    public virtual DbSet<User> User1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GONZALO;Database=DataBaseFirst;User Id=sa;Password=Gonzalo1;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_1__3213E83FB2F3F688");

            entity.ToTable("User_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .HasColumnName("address");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .HasColumnName("DNI");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
