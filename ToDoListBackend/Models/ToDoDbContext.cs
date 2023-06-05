using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBackend.Models;

public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ToDoDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07F93AD8DD");

            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.Title).HasMaxLength(40);
        });

        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ToDos__3214EC0784C6F52C");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            entity.Property(e => e.Name).HasMaxLength(25);

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ToDos)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK__ToDos__AssignedT__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
