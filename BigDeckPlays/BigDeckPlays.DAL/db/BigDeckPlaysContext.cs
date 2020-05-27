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
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bigdeckplays;Username=postgres;Password=secret_db_password");
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
                    .HasColumnType("UUID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmc).HasColumnName("cmc");

                entity.Property(e => e.Colors)
                    .HasColumnName("colors")
                    .HasMaxLength(255);

                entity.Property(e => e.ColorIdentity)
                    .HasColumnName("color_identity")
                    .HasMaxLength(255);

                entity.Property(e => e.ManaCost)
                    .HasColumnName("mana_cost")
                    .HasMaxLength(255);

                entity.Property(e => e.OracleText)
                    .HasColumnName("oracle_text");

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasMaxLength(255);

                entity.Property(e => e.Toughness)
                    .HasColumnName("toughness")
                    .HasMaxLength(255);

                entity.Property(e => e.Toughness)
                    .HasColumnName("loyalty")
                    .HasMaxLength(255);

                entity.Property(e => e.Types)
                    .HasColumnName("types")
                    .HasMaxLength(255);

                entity.Property(e => e.Subtypes)
                    .HasColumnName("subtypes")
                    .HasMaxLength(255);

                entity.Property(e => e.EdhrecRank)
                    .HasColumnName("edhrec_rank");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved");

                entity.Property(e => e.CommanderLegality)
                    .HasColumnName("commander_legality")
                    .HasMaxLength(255);

                entity.Property(e => e.StandardLegality)
                    .HasColumnName("standard_legality")
                    .HasMaxLength(255);

                entity.Property(e => e.BrawlLegality)
                    .HasColumnName("brawl_legality")
                    .HasMaxLength(255);

                entity.Property(e => e.PioneerLegality)
                    .HasColumnName("pioneer_legality")
                    .HasMaxLength(255);

                entity.Property(e => e.ModernLegality)
                    .HasColumnName("modern_legality")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CardFace>(entity =>
            {
                entity.ToTable("card_face", "dbo");

                entity.HasIndex(e => e.Name)
                .HasName("card_face_name_key");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.ManaCost)
                    .HasColumnName("mana_cost")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OracleText)
                    .HasColumnName("oracle_text");

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasMaxLength(255);

                entity.Property(e => e.Toughness)
                    .HasColumnName("toughness")
                    .HasMaxLength(255);

                entity.Property(e => e.Loyalty)
                    .HasColumnName("loyalty")
                    .HasMaxLength(255);

                entity.Property(e => e.Types)
                    .HasColumnName("types")
                    .HasMaxLength(255);

                entity.Property(e => e.Subtypes)
                    .HasColumnName("subtypes")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardFaces)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_face_card_id_fkey");
            });

            modelBuilder.Entity<CardSet>(entity =>
            {
                entity.ToTable("card_set", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasColumnType("UUID");

                entity.Property(e => e.HighPrice)
                    .HasColumnName("high_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.LowPrice)
                    .HasColumnName("low_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.MedianPrice)
                    .HasColumnName("median_price")
                    .HasColumnType("numeric");

                entity.Property(e => e.SetId)
                    .IsRequired()
                    .HasColumnName("set_id")
                    .HasColumnType("UUID");

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasColumnType("UUID");

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasColumnName("tag_id")
                    .HasColumnType("UUID");

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CommanderId)
                    .IsRequired()
                    .HasColumnName("commander_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CommanderNavigation)
                    .WithMany(p => p.Deck)
                    .HasForeignKey(d => d.CommanderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deck_commander_fkey");
            });

            modelBuilder.Entity<DeckCard>(entity =>
            {
                entity.ToTable("deck_card", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasColumnType("UUID");

                entity.Property(e => e.DeckId)
                    .HasColumnName("deck_id")
                    .HasColumnType("UUID");

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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.DeckId)
                    .HasColumnName("deck_id")
                    .HasColumnType("UUID");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasColumnType("UUID");

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
                    .HasColumnType("UUID");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.SetType)
                    .HasColumnName("set_type")
                    .HasMaxLength(255);

                entity.Property(e => e.ReleasedAt)
                    .HasColumnName("released_at")
                    .HasColumnType("DATE");

                entity.Property(e => e.BlockCode)
                    .HasColumnName("block_code")
                    .HasMaxLength(255);

                entity.Property(e => e.Block)
                    .HasColumnName("block")
                    .HasMaxLength(255);

                entity.Property(e => e.CardCount)
                    .HasColumnName("card_count");

                entity.Property(e => e.FoilOnly)
                    .HasColumnName("foil_only");

                entity.Property(e => e.Completed)
                    .HasColumnName("completed");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CollectionCard>(entity =>
            {
                entity.ToTable("collection_card", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasColumnName("card_id")
                    .HasColumnType("UUID");

                entity.Property(e => e.CollectionId)
                    .IsRequired()
                    .HasColumnName("collection_id")
                    .HasColumnType("UUID");

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
