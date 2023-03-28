using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games4Kids
{
    public partial class Games4KidsContext : DbContext
    {
        public Games4KidsContext()
        {
        }

        public Games4KidsContext(DbContextOptions<Games4KidsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GameSetting> GameSettings { get; set; }
        public virtual DbSet<MatchRecord> MatchRecords { get; set; }
        public virtual DbSet<PlayerRecord> PlayerRecords { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=Games4Kids;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSetting>(entity =>
            {
                entity.HasKey(e => e.SettingsId)
                    .HasName("settings_pk");

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");

                entity.Property(e => e.Difficulty).HasDefaultValueSql("((1))");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.LimitTime).HasDefaultValueSql("((24))");

                entity.Property(e => e.Music).HasDefaultValueSql("((1))");

                entity.Property(e => e.SoundEffect).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameSettings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("settings_users_fk");
            });

            modelBuilder.Entity<MatchRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("record_pk");

                entity.ToTable("MatchRecord");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Points).HasMaxLength(9);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MatchRecords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matchRecord_users_fk");
            });

            modelBuilder.Entity<PlayerRecord>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.UserId)
                        .HasName("playerRecordID_pk");

                entity.Property(e => e.CurrentRank).HasMaxLength(30);

                entity.Property(e => e.TotalPoints).HasMaxLength(9);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PlayerRecords_users_fk");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.NextLevelPoints)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.RankId)
                    .HasColumnName("RankID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RankName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Nickname)
                    .HasName("UQ__Users__CC6CD17E30DBE71E")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ParentPin)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
