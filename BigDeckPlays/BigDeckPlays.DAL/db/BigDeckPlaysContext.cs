using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BigDeckPlays.DAL.db
{
    public partial class BigDeckPlaysContext : DbContext
    {
        public BigDeckPlaysContext()
        {
        }

        public BigDeckPlaysContext(DbContextOptions<BigDeckPlaysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<CardSet> CardSet { get; set; }
        public virtual DbSet<CardTag> CardTag { get; set; }
        public virtual DbSet<Deck> Deck { get; set; }
        public virtual DbSet<DeckCard> DeckCard { get; set; }
        public virtual DbSet<DeckTag> DeckTag { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<CollectionCard> CollectionCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // warning To protect potentially sensitive information in your connection string,
                // you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263
                // for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bigdeckplays;Username=postgres;Password=d465dda32910478494c5e34d05627938");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("card_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmc).HasColumnName("cmc");

                entity.Property(e => e.Colors)
                    .HasColumnName("colors")
                    .HasMaxLength(255);

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OracleText)
                    .HasColumnName("oracle_text")
                    .HasMaxLength(255);

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasMaxLength(255);

                entity.Property(e => e.SubTypes)
                    .HasColumnName("sub_types")
                    .HasMaxLength(255);

                entity.Property(e => e.Toughness)
                    .HasColumnName("toughness")
                    .HasMaxLength(255);

                entity.Property(e => e.Types)
                    .HasColumnName("types")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CardSet>(entity =>
            {
                entity.ToTable("card_set", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasMaxLength(255);

                entity.Property(e => e.HighPrice)
                    .HasColumnName("high_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.LowPrice)
                    .HasColumnName("low_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.MedianPrice)
                    .HasColumnName("median_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SetId)
                    .IsRequired()
                    .HasColumnName("set_id")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardSet)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_set_card_id_fkey");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.CardSet)
                    .HasForeignKey(d => d.SetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_set_set_id_fkey");
            });

            modelBuilder.Entity<CardTag>(entity =>
            {
                entity.ToTable("card_tag", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasMaxLength(255);

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardTag)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_tag_card_id_fkey");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.CardTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_tag_tag_id_fkey");
            });

            modelBuilder.Entity<Deck>(entity =>
            {
                entity.ToTable("deck", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("deck_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commander)
                    .IsRequired()
                    .HasColumnName("commander")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CommanderNavigation)
                    .WithMany(p => p.Deck)
                    .HasForeignKey(d => d.Commander)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_commander_fkey");
            });

            modelBuilder.Entity<DeckCard>(entity =>
            {
                entity.ToTable("deck_card", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasMaxLength(255);

                entity.Property(e => e.DeckId).HasColumnName("deck_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.DeckCard)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_card_card_id_fkey");

                entity.HasOne(d => d.Deck)
                    .WithMany(p => p.DeckCard)
                    .HasForeignKey(d => d.DeckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_card_deck_id_fkey");
            });

            modelBuilder.Entity<DeckTag>(entity =>
            {
                entity.ToTable("deck_tag", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeckId).HasColumnName("deck_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Deck)
                    .WithMany(p => p.DeckTag)
                    .HasForeignKey(d => d.DeckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_tag_deck_id_fkey");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.DeckTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_tag_tag_id_fkey");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("set", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("set_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255);

                entity.Property(e => e.Border)
                    .HasColumnName("border")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CollectionCard>(entity =>
            {
                entity.ToTable("collection_card", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id");

                entity.Property(e => e.CollectionId)
                    .IsRequired()
                    .HasColumnName("collection_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CollectionCard)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_card_card_id_fkey");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.CollectionCard)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_card_collection_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
