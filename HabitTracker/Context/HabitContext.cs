using HabitTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class HabitContext : DbContext
{
    public HabitContext(DbContextOptions<HabitContext> options) : base(options)
    {
    }

    public DbSet<Habit> Habits { get; set; }
    public DbSet<HabitLog> HabitLogs { get; set; }
}