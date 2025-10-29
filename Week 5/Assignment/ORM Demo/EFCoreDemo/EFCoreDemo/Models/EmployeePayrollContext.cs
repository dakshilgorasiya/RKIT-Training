using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EFCoreDemo.Models;

public partial class EmployeePayrollContext : DbContext
{
    public EmployeePayrollContext()
    {
    }

    public EmployeePayrollContext(DbContextOptions<EmployeePayrollContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeSalarySummary> EmployeeSalarySummaries { get; set; }

    public virtual DbSet<T01> T01s { get; set; }

    public virtual DbSet<T02> T02s { get; set; }

    public virtual DbSet<T03> T03s { get; set; }

    public virtual DbSet<T04> T04s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=employee_payroll;user=root;password=Dakshil@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<EmployeeSalarySummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("employee_salary_summary");

            entity.Property(e => e.CoalesceSumT03f030)
                .HasPrecision(30, 2)
                .HasColumnName("COALESCE(SUM(T03F03), 0)");
            entity.Property(e => e.CountT03f03).HasColumnName("COUNT(T03F03)");
            entity.Property(e => e.T01f01).HasColumnName("T01F01");
            entity.Property(e => e.T01f02)
                .HasMaxLength(50)
                .HasColumnName("T01F02");
            entity.Property(e => e.T01f04)
                .HasPrecision(8, 2)
                .HasColumnName("T01F04");
            entity.Property(e => e.T02f02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
        });

        modelBuilder.Entity<T01>(entity =>
        {
            entity.HasKey(e => e.T01f01).HasName("PRIMARY");

            entity.ToTable("t01");

            entity.HasIndex(e => e.T01f03, "FK_T01F03");

            entity.Property(e => e.T01f01)
                .ValueGeneratedNever()
                .HasColumnName("T01F01");
            entity.Property(e => e.T01f02)
                .HasMaxLength(50)
                .HasColumnName("T01F02");
            entity.Property(e => e.T01f03).HasColumnName("T01F03");
            entity.Property(e => e.T01f04)
                .HasPrecision(8, 2)
                .HasColumnName("T01F04");

            entity.HasOne(d => d.T01f03Navigation).WithMany(p => p.T01s)
                .HasForeignKey(d => d.T01f03)
                .HasConstraintName("FK_T01F03");
        });

        modelBuilder.Entity<T02>(entity =>
        {
            entity.HasKey(e => e.T02f01).HasName("PRIMARY");

            entity.ToTable("t02");

            entity.Property(e => e.T02f01)
                .ValueGeneratedNever()
                .HasColumnName("T02F01");
            entity.Property(e => e.T02f02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
        });

        modelBuilder.Entity<T03>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("t03");

            entity.HasIndex(e => e.T03f01, "FK_T03F01");

            entity.Property(e => e.T03f01).HasColumnName("T03F01");
            entity.Property(e => e.T03f02)
                .HasDefaultValueSql("curdate()")
                .HasColumnName("T03F02");
            entity.Property(e => e.T03f03)
                .HasPrecision(8, 2)
                .HasColumnName("T03F03");

            entity.HasOne(d => d.T03f01Navigation).WithMany()
                .HasForeignKey(d => d.T03f01)
                .HasConstraintName("FK_T03F01");
        });

        modelBuilder.Entity<T04>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("t04");

            entity.HasIndex(e => e.T04f01, "FK_T04F01");

            entity.Property(e => e.T04f01).HasColumnName("T04F01");
            entity.Property(e => e.T04f02)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp")
                .HasColumnName("T04F02");
            entity.Property(e => e.T04f03)
                .HasPrecision(8, 2)
                .HasColumnName("T04F03");

            entity.HasOne(d => d.T04f01Navigation).WithMany()
                .HasForeignKey(d => d.T04f01)
                .HasConstraintName("FK_T04F01");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
