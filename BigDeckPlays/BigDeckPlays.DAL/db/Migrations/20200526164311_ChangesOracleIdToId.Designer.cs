﻿// <auto-generated />
using System;
using BigDeckPlays.DAL.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BigDeckPlays.DAL.db.Migrations
{
    [DbContext(typeof(BigDeckPlaysContext))]
    [Migration("20200526164311_ChangesOracleIdToId")]
    partial class ChangesOracleIdToId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BigDeckPlays.DAL.db.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<string>("BrawlLegality")
                        .HasColumnName("brawl_legality")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("Cmc")
                        .HasColumnName("cmc")
                        .HasColumnType("integer");

                    b.Property<string>("ColorIdentity")
                        .HasColumnName("color_identity")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Colors")
                        .HasColumnName("colors")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CommanderLegality")
                        .HasColumnName("commander_legality")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("EdhrecRank")
                        .HasColumnName("edhrec_rank")
                        .HasColumnType("integer");

                    b.Property<string>("Loyalty")
                        .HasColumnType("text");

                    b.Property<string>("ManaCost")
                        .HasColumnName("mana_cost")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ModernLegality")
                        .HasColumnName("modern_legality")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("OracleText")
                        .HasColumnName("oracle_text")
                        .HasColumnType("text");

                    b.Property<string>("PioneerLegality")
                        .HasColumnName("pioneer_legality")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Power")
                        .HasColumnName("power")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Reserved")
                        .HasColumnName("reserved")
                        .HasColumnType("boolean");

                    b.Property<string>("StandardLegality")
                        .HasColumnName("standard_legality")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subtypes")
                        .HasColumnName("subtypes")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Toughness")
                        .HasColumnName("loyalty")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Types")
                        .HasColumnName("types")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("card_name_key");

                    b.ToTable("card","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardFace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<string>("Loyalty")
                        .HasColumnName("loyalty")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("ManaCost")
                        .HasColumnName("mana_cost")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("OracleText")
                        .HasColumnName("oracle_text")
                        .HasColumnType("text");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Power")
                        .HasColumnName("power")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subtypes")
                        .HasColumnName("subtypes")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Toughness")
                        .HasColumnName("toughness")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Types")
                        .HasColumnName("types")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("card_face_name_key");

                    b.HasIndex("ParentId");

                    b.ToTable("card_face","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CardId")
                        .HasColumnName("card_id")
                        .HasColumnType("UUID");

                    b.Property<decimal?>("HighPrice")
                        .HasColumnName("high_price")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("LowPrice")
                        .HasColumnName("low_price")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("MedianPrice")
                        .HasColumnName("median_price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SetId")
                        .HasColumnName("set_id")
                        .HasColumnType("UUID");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("SetId");

                    b.ToTable("card_set","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CardId")
                        .HasColumnName("card_id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("TagId")
                        .HasColumnName("tag_id")
                        .HasColumnType("UUID");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("TagId");

                    b.ToTable("card_tag","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("collection","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CollectionCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CardId")
                        .HasColumnName("card_id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CollectionId")
                        .HasColumnName("collection_id")
                        .HasColumnType("UUID");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("CollectionId");

                    b.ToTable("collection_card","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.Deck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CommanderId")
                        .HasColumnName("commander_id")
                        .HasColumnType("uuid")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CommanderId");

                    b.ToTable("deck","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.DeckCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("CardId")
                        .HasColumnName("card_id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("DeckId")
                        .HasColumnName("deck_id")
                        .HasColumnType("UUID");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("quantity")
                        .HasColumnType("integer")
                        .HasDefaultValueSql("1");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("DeckId");

                    b.ToTable("deck_card","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.DeckTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<Guid>("DeckId")
                        .HasColumnName("deck_id")
                        .HasColumnType("UUID");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("TagId")
                        .HasColumnName("tag_id")
                        .HasColumnType("UUID");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.HasIndex("TagId");

                    b.ToTable("deck_tag","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("BlockCode")
                        .HasColumnName("block_code")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("CardCount")
                        .HasColumnName("card_count")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("FoilOnly")
                        .HasColumnName("foil_only")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("ReleasedAt")
                        .HasColumnName("released_at")
                        .HasColumnType("DATE");

                    b.Property<string>("SetType")
                        .HasColumnName("set_type")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("set_name_key");

                    b.ToTable("set","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("UUID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tag","dbo");
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardFace", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "Card")
                        .WithMany("CardFaces")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("card_face_card_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardSet", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "Card")
                        .WithMany("CardSet")
                        .HasForeignKey("CardId")
                        .HasConstraintName("card_set_card_id_fkey")
                        .IsRequired();

                    b.HasOne("BigDeckPlays.DAL.db.Set", "Set")
                        .WithMany("CardSet")
                        .HasForeignKey("SetId")
                        .HasConstraintName("card_set_set_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CardTag", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "Card")
                        .WithMany("CardTag")
                        .HasForeignKey("CardId")
                        .HasConstraintName("card_tag_card_id_fkey")
                        .IsRequired();

                    b.HasOne("BigDeckPlays.DAL.db.Tag", "Tag")
                        .WithMany("CardTag")
                        .HasForeignKey("TagId")
                        .HasConstraintName("card_tag_tag_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.CollectionCard", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "Card")
                        .WithMany("CollectionCard")
                        .HasForeignKey("CardId")
                        .HasConstraintName("collection_card_card_id_fkey")
                        .IsRequired();

                    b.HasOne("BigDeckPlays.DAL.db.Collection", "Collection")
                        .WithMany("CollectionCard")
                        .HasForeignKey("CollectionId")
                        .HasConstraintName("collection_card_collection_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.Deck", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "CommanderNavigation")
                        .WithMany("Deck")
                        .HasForeignKey("CommanderId")
                        .HasConstraintName("deck_commander_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.DeckCard", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Card", "Card")
                        .WithMany("DeckCard")
                        .HasForeignKey("CardId")
                        .HasConstraintName("deck_card_card_id_fkey")
                        .IsRequired();

                    b.HasOne("BigDeckPlays.DAL.db.Deck", "Deck")
                        .WithMany("DeckCard")
                        .HasForeignKey("DeckId")
                        .HasConstraintName("deck_card_deck_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("BigDeckPlays.DAL.db.DeckTag", b =>
                {
                    b.HasOne("BigDeckPlays.DAL.db.Deck", "Deck")
                        .WithMany("DeckTag")
                        .HasForeignKey("DeckId")
                        .HasConstraintName("deck_tag_deck_id_fkey")
                        .IsRequired();

                    b.HasOne("BigDeckPlays.DAL.db.Tag", "Tag")
                        .WithMany("DeckTag")
                        .HasForeignKey("TagId")
                        .HasConstraintName("deck_tag_tag_id_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
