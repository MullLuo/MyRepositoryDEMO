using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace coredb
{
    public partial class MyWebsiteDBContext : DbContext
    {
        public MyWebsiteDBContext()
        {
        }

        public MyWebsiteDBContext(DbContextOptions<MyWebsiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMember> TMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:mywebsiteserver.database.windows.net,1433;Initial Catalog=MyWebsiteDB;Persist Security Info=False;User ID=joeii0126;Password=zxcv123%%%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tMember");

                entity.Property(e => e.FAge).HasColumnName("fAge");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasMaxLength(10);

                entity.Property(e => e.FSex)
                    .IsRequired()
                    .HasColumnName("fSex")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
