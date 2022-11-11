using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vacation_Manager.VacationManager;

public partial class VacationManagerContext : DbContext
{
    public VacationManagerContext()
    {
    }

    public VacationManagerContext(DbContextOptions<VacationManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTeam> UserTeams { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSqlLocalDb;Database=Vacation Manager;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07E8AAE42A");

            entity.ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Team).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_TeamId");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC0758E33905");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.Teams)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_ProjectId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC076C7BC1D0");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserTeam>(entity =>
        {
            entity.HasKey(e => e.LeaderId).HasName("PK__UserTeam__FCCA6516ABE801C7");

            entity.ToTable("UserTeam");

            entity.Property(e => e.LeaderId).ValueGeneratedNever();

            entity.HasOne(d => d.Team).WithMany(p => p.UserTeams)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__UserTeam__TeamId__2E1BDC42");

            entity.HasOne(d => d.User).WithMany(p => p.UserTeams)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserTeam__UserId__2D27B809");
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vacation__3214EC0705B1422F");

            entity.ToTable("Vacation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BeggingDate).HasColumnType("date");
            entity.Property(e => e.DateOfCreation).HasColumnType("date");
            entity.Property(e => e.EndingDate).HasColumnType("date");

            entity.HasOne(d => d.User).WithMany(p => p.Vacations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vacation__UserId__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
