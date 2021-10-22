using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ElearnStaffAPI.ElearnModel
{
    public partial class elearnContext : DbContext
    {
        public elearnContext()
        {
        }

        public elearnContext(DbContextOptions<elearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Usercourse> Usercourses { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-482\\SQLSERVER2021CK;Database=elearn;Trusted_Connection=True;");
            }
            //
            //"Server=tcp:teamsix.database.windows.net,1433;Initial Catalog=elearn;Persist Security Info=False;User ID=chokkateamsix;Password=Chokka@2000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(100)
                    .HasColumnName("coursename");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("modules");

                entity.Property(e => e.Moduleid).HasColumnName("moduleid");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Modulename)
                    .HasMaxLength(50)
                    .HasColumnName("modulename");

                entity.Property(e => e.Video)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("video");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Age)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Usercourse>(entity =>
            {
                entity.HasKey(e => new { e.Stuid, e.Coid })
                    .HasName("PK__Usercour__6D9F6DC2E6D91329");

                entity.Property(e => e.Stuid).HasColumnName("stuid");

                entity.Property(e => e.Coid).HasColumnName("coid");

                entity.HasOne(d => d.Co)
                    .WithMany(p => p.Usercourses)
                    .HasForeignKey(d => d.Coid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usercourse__coid__5FB337D6");

                entity.HasOne(d => d.Stu)
                    .WithMany(p => p.Usercourses)
                    .HasForeignKey(d => d.Stuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usercours__stuid__5EBF139D");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Age)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Expertise)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("expertise");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
