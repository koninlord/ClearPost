using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class FlearanceContext : DbContext
    {
        public FlearanceContext()
        {
        }

        public FlearanceContext(DbContextOptions<FlearanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Deleted && entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;

                    entity.GetType().GetProperty("RecStatus").SetValue(entity, 'D');
                }
            }

            return base.SaveChanges();
        }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.HasKey(e => e.FeeId);

                entity.Property(e => e.FeeId).HasColumnName("FeeID");

                entity.Property(e => e.AmountOwing).HasMaxLength(10);

                entity.Property(e => e.AmountPaid)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FeeAmount)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IsOwing)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.RecStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fees_Student");
            });

            modelBuilder.Entity<Halls>(entity =>
            {
                entity.HasKey(e => e.HallId);

                entity.Property(e => e.HallId).HasColumnName("HallID");

                entity.Property(e => e.HallName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsOwing)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.KeyReturned)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.RecStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Halls_Student");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.Property(e => e.HascollectedBook)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.RecStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_Student");
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasKey(e => e.SportId);

                entity.Property(e => e.SportId).HasColumnName("SportID");

                entity.Property(e => e.IsOwingKit)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.RecStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SportsType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Sports)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sports_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Departments");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
