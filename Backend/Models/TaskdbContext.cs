using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskHub.Models;

public partial class TaskdbContext : DbContext
{
    public TaskdbContext()
    {
    }

    public TaskdbContext(DbContextOptions<TaskdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todotask> Todotasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todotask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todotasks");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Pending'")
                .HasColumnType("enum('Pending','Completed')");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
