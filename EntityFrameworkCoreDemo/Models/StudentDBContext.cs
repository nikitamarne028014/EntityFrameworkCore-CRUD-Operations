using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore_DataBaseFirst_Demo.Models
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-3UCJ7LDS;Database=StudentDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentDivision).HasMaxLength(10);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Teacher1");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.SubjectExpertise)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
