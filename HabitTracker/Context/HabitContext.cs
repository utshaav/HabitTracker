using HabitTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class HabitContext : DbContext
{
    public HabitContext(DbContextOptions<HabitContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habit>()
            .HasOne(h => h.HabitGroup)
            .WithMany(g => g.Habits)
            .HasForeignKey(h => h.HabitGroupId)
            .OnDelete(DeleteBehavior.Cascade); // or Restrict

         modelBuilder.Entity<HabitLog>()
            .HasOne(hl => hl.Habit)
            .WithMany(h => h.HabitLogs)
            .HasForeignKey(hl => hl.HabitId)
            .OnDelete(DeleteBehavior.Cascade); // or Restrict
    }

    public DbSet<Habit> Habits { get; set; }
    public DbSet<HabitLog> HabitLogs { get; set; }
    public DbSet<HabitGroup> HabitGroups { get; set; }
}