using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Plagiarism_Checker.Models;

namespace Plagiarism_Checker
{
    public partial class UniverContext : IdentityDbContext<User>
    {
        public UniverContext()
        {
        }

        public UniverContext(DbContextOptions<UniverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Solution> Solution { get; set; }
        public virtual DbSet<StudentLesson> StudentLesson { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Time> Time { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Univer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Applications>(entity =>
            {
                entity.Property(e => e.IsTeacher).HasColumnName("isTeacher");

                entity.Property(e => e.Nin).HasColumnName("nin");

                entity.Property(e => e.StudentNumber).HasColumnName("student_number");
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Nin).HasColumnName("nin");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.StudentLessonId).HasColumnName("student_lesson_id");

                entity.Property(e => e.StudentNumber).HasColumnName("student_number");

                //entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.Requirenments)
                    .IsRequired()
                    .HasColumnName("requirenments")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Day1)
                    .IsRequired()
                    .HasColumnName("day")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("student_id")
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HwTaskId).HasColumnName("hw_task_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.TestTaskId).HasColumnName("test_task_id");

                entity.HasOne(d => d.HwTask)
                    .WithMany(p => p.LessonHwTask)
                    .HasForeignKey(d => d.HwTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Task");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Schedule");

                entity.HasOne(d => d.TestTask)
                    .WithMany(p => p.LessonTestTask)
                    .HasForeignKey(d => d.TestTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Task1");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DayId).HasColumnName("day_id");

                entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasColumnName("teacher_id")
                    .HasMaxLength(450);

                entity.Property(e => e.TimeId).HasColumnName("time_id");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Day");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Discipline");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Group");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_AspNetUsers");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Time");
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file");
            });

            modelBuilder.Entity<StudentLesson>(entity =>
            {
                entity.ToTable("Student_lesson");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LessonId).HasColumnName("lesson_id");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("student_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.StudentLesson)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_lesson_Lesson");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentLesson)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_lesson_AspNetUsers");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.SolutionId).HasColumnName("solution_id");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Assignment");

                entity.HasOne(d => d.Solution)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.SolutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Solution");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Time1)
                    .HasColumnName("time")
                    .HasColumnType("time(0)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
