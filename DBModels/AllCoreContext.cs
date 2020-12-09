using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class AllCoreContext : DbContext
    {
        public AllCoreContext()
        {
        }

        public AllCoreContext(DbContextOptions<AllCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DivList> DivList { get; set; }
        public virtual DbSet<Upazila> Upazila { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AllCore;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BedInformation>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Rent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BedInformation)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.DivListId).HasColumnName("DivListID");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.DivList)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.DivListId);
            });

            modelBuilder.Entity<DivList>(entity =>
            {
                entity.ToTable("divList");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.IsMarried)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Upazila>(entity =>
            {
                entity.Property(e => e.DistrictId).HasColumnName("districtId");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Upazila)
                    .HasForeignKey(d => d.DistrictId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
