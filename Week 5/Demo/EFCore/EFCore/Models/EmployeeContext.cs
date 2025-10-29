using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EFCore.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpDept> EmpDepts { get; set; }

    public virtual DbSet<EmpName> EmpNames { get; set; }

    public virtual DbSet<T01> T01s { get; set; }

    public virtual DbSet<T01View> T01Views { get; set; }

    public virtual DbSet<T02> T02s { get; set; }

    public virtual DbSet<T03> T03s { get; set; }

    public virtual DbSet<GetEmployeeByDepartmentResult> GetEmployeeByDepartmentResults { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Dakshil@123;database=employee", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<EmpDept>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("emp_dept");

            entity.Property(e => e.T01f02)
                .HasMaxLength(40)
                .HasColumnName("T01F02");
            entity.Property(e => e.T02f01).HasColumnName("T02F01");
            entity.Property(e => e.T02f02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
            entity.Property(e => e.T02f03)
                .HasMaxLength(50)
                .HasColumnName("T02F03");
        });

        modelBuilder.Entity<GetEmployeeByDepartmentResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView(null);
            entity.Property(e => e.T02F01).HasColumnName("T02F01");
            entity.Property(e => e.T02F02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
            entity.Property(e => e.T02F03)
                .HasMaxLength(50)
                .HasColumnName("T02F03");
        });

        modelBuilder.Entity<EmpName>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("emp_name");

            entity.Property(e => e.T02f01).HasColumnName("T02F01");
            entity.Property(e => e.T02f02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
            entity.Property(e => e.T02f03)
                .HasMaxLength(50)
                .HasColumnName("T02F03");
        });

        modelBuilder.Entity<T01>(entity =>
        {
            entity.HasKey(e => e.T01f01).HasName("PRIMARY");

            entity.ToTable("t01");

            entity.Property(e => e.T01f01)
                .ValueGeneratedNever()
                .HasColumnName("T01F01");
            entity.Property(e => e.T01f02)
                .HasMaxLength(40)
                .HasColumnName("t01f02");
            entity.Property(e => e.T01f03)
                .HasMaxLength(100)
                .HasColumnName("T01F03");
        });

        modelBuilder.Entity<T01View>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("t01_view");

            entity.Property(e => e.T01f01).HasColumnName("T01F01");
            entity.Property(e => e.T01f02)
                .HasMaxLength(40)
                .HasColumnName("T01F02");
            entity.Property(e => e.T01f03)
                .HasMaxLength(100)
                .HasColumnName("T01F03");
        });

        modelBuilder.Entity<T02>(entity =>
        {
            entity.HasKey(e => e.T02f01).HasName("PRIMARY");

            entity.ToTable("t02");

            entity.HasIndex(e => e.T02f08, "FK_T02F08");

            entity.HasIndex(e => e.T02f04, "FT_INDEX_TO2F04")
                .IsUnique()
                .HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.T02f01)
                .ValueGeneratedNever()
                .HasColumnName("T02F01");
            entity.Property(e => e.T02f02)
                .HasMaxLength(50)
                .HasColumnName("T02F02");
            entity.Property(e => e.T02f03)
                .HasMaxLength(50)
                .HasColumnName("T02F03");
            entity.Property(e => e.T02f04)
                .HasMaxLength(100)
                .HasColumnName("T02F04");
            entity.Property(e => e.T02f05).HasColumnName("T02F05");
            entity.Property(e => e.T02f06)
                .HasMaxLength(50)
                .HasColumnName("T02F06");
            entity.Property(e => e.T02f07)
                .HasPrecision(10, 2)
                .HasColumnName("T02F07");
            entity.Property(e => e.T02f08).HasColumnName("T02F08");

            entity.HasOne(d => d.T02f08Navigation).WithMany(p => p.T02s)
                .HasForeignKey(d => d.T02f08)
                .HasConstraintName("FK_T02F08");
        });

        modelBuilder.Entity<T03>(entity =>
        {
            entity.HasKey(e => new { e.T03f01, e.T03f04 })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("t03");

            entity.Property(e => e.T03f01).HasColumnName("T03F01");
            entity.Property(e => e.T03f04).HasColumnName("T03F04");
            entity.Property(e => e.T03f02)
                .HasMaxLength(50)
                .HasColumnName("T03F02");
            entity.Property(e => e.T03f03)
                .HasMaxLength(50)
                .HasColumnName("T03F03");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
