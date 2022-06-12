using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace kolokwiumEF.Models
{
    public partial class s20279Context : DbContext
    {
        public s20279Context()
        {
        }

        public s20279Context(DbContextOptions<s20279Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<CopyOfAlbum> CopyOfAlbums { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.ToTable("Album");

                entity.Property(e => e.IdAlbum)
                    .ValueGeneratedNever()
                    .HasColumnName("idAlbum");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.HasOne(d => d.IdMusicLabelNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdMusicLabel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Album_Copy_of_Album");
            });

            modelBuilder.Entity<CopyOfAlbum>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("Copy_of_Album_pk");

                entity.ToTable("Copy_of_Album");

                entity.Property(e => e.IdMusicLabel).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("Musician_pk");

                entity.ToTable("Musician");

                entity.HasIndex(e => e.FirstName, "payment_data_ak_1")
                    .IsUnique();

                entity.Property(e => e.IdMusician)
                    .ValueGeneratedNever()
                    .HasColumnName("idMusician");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MusicianTrack>(entity =>
            {
                entity.HasKey(e => new { e.IdTrack, e.IdMusician })
                    .HasName("Musician_Track_pk");

                entity.ToTable("Musician_Track");

                entity.Property(e => e.IdTrack).HasColumnName("idTrack");

                entity.Property(e => e.IdMusician).HasColumnName("idMusician");

                entity.HasOne(d => d.IdMusicianNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_details_payment_data");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Track");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.ToTable("Track");

                entity.Property(e => e.IdTrack)
                    .ValueGeneratedNever()
                    .HasColumnName("idTrack");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMusicAlbumNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdMusicAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Track_Album");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
