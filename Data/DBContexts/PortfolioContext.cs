using System;
using System.Collections.Generic;
using Admin_Portfolio.Data.Models;
using Admin_Portfolio.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin_Portfolio.Data.DBContexts;

public partial class PortfolioContext : DbContext// IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public PortfolioContext()
    {

    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Myservice> Myservices { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=portfolio;uid=root;pwd=04042003", ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("about")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasMaxLength(50)
                .HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Header)
                .HasMaxLength(100)
                .HasColumnName("header");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Skype)
                .HasMaxLength(50)
                .HasColumnName("skype");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(500)
                .HasColumnName("subtitle");
            entity.Property(e => e.Work)
                .HasMaxLength(100)
                .HasColumnName("work");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admins")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("counter")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(100)
                .HasColumnName("subtitle");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("education")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("date");
            entity.Property(e => e.Header)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("header");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(1000)
                .HasDefaultValueSql("'0'")
                .HasColumnName("subtitle");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("experience")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("date");
            entity.Property(e => e.Header)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("header");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(1000)
                .HasDefaultValueSql("'0'")
                .HasColumnName("subtitle");
        });

        modelBuilder.Entity<Expertise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("expertise")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Header)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("header");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("icon");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(500)
                .HasDefaultValueSql("'0'")
                .HasColumnName("subtitle");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("language")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("name");
            entity.Property(e => e.Percent).HasColumnName("percent");
        });

        modelBuilder.Entity<Myservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("myservices")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Header)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("header");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("icon");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(1000)
                .HasDefaultValueSql("'0'")
                .HasColumnName("subtitle");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("skills")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Percent).HasColumnName("percent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
