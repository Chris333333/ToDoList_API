using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities.ToDoListDatabase;

public partial class ToDoListContext : DbContext
{
    public ToDoListContext()
    {
    }

    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Layout> Layouts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkPosition> WorkPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CHRIS_PC;Database=ToDoList; Trusted_Connection=True; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Layout>(entity =>
        {
            entity.ToTable("Layout");

            entity.Property(e => e.LayoutId).HasColumnName("LayoutID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Path).HasColumnType("text");

            entity.HasOne(d => d.Location).WithMany(p => p.Layouts)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Layout_Location");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Street).HasColumnType("text");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.CompletedDt)
                .HasColumnType("datetime")
                .HasColumnName("CompletedDT");
            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.LayoutId).HasColumnName("LayoutID");
            entity.Property(e => e.Task1)
                .HasColumnType("text")
                .HasColumnName("Task");

            entity.HasOne(d => d.Layout).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.LayoutId)
                .HasConstraintName("FK_Tasks_Layout");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Login).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Surname).HasColumnType("text");
            entity.Property(e => e.WorkPositionId).HasColumnName("WorkPositionID");

            entity.HasOne(d => d.Location).WithMany(p => p.Users)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Location");

            entity.HasOne(d => d.WorkPosition).WithMany(p => p.Users)
                .HasForeignKey(d => d.WorkPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_WorkPosition");
        });

        modelBuilder.Entity<WorkPosition>(entity =>
        {
            entity.ToTable("WorkPosition");

            entity.Property(e => e.WorkPositionId).HasColumnName("WorkPositionID");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.ShortName).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
