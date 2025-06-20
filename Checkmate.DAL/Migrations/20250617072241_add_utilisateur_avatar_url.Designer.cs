﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Checkmate.DAL.Database;

#nullable disable

namespace Checkmate.DAL.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20250617072241_add_utilisateur_avatar_url")]
    partial class add_utilisateur_avatar_url
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MM_Tournament_Category", b =>
                {
                    b.Property<int>("tournament_id")
                        .HasColumnType("int");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.HasKey("tournament_id", "category_id");

                    b.HasIndex("category_id");

                    b.ToTable("MM_Tournament_Category");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxAge")
                        .HasColumnType("int")
                        .HasColumnName("max_age");

                    b.Property<int>("MinAge")
                        .HasColumnType("int")
                        .HasColumnName("min_age");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Checkmate.Domain.Models.GameRoundPlayerTournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlackElo")
                        .HasColumnType("int")
                        .HasColumnName("black_elo");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("result");

                    b.Property<int>("Round")
                        .HasColumnType("int")
                        .HasColumnName("round");

                    b.Property<int>("WhiteElo")
                        .HasColumnType("int")
                        .HasColumnName("white_elo");

                    b.Property<int>("black_id")
                        .HasColumnType("int");

                    b.Property<int>("tournament_id")
                        .HasColumnType("int");

                    b.Property<int>("white_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("black_id");

                    b.HasIndex("tournament_id");

                    b.HasIndex("white_id");

                    b.ToTable("GameRoundPlayerTournaments", (string)null);
                });

            modelBuilder.Entity("Checkmate.Domain.Models.InscriptionPlayerTournament", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int")
                        .HasColumnName("player_id");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int")
                        .HasColumnName("tournament_id");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("datetime")
                        .HasColumnName("inscription_date");

                    b.Property<DateTime?>("CanceledAt")
                        .HasColumnType("datetime")
                        .HasColumnName("canceled_at");

                    b.HasKey("PlayerId", "TournamentId", "InscriptionDate")
                        .HasName("PK_InscriptionPlayerTournaments");

                    b.HasIndex("TournamentId");

                    b.ToTable("InscriptionPlayerTournaments", (string)null);
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("country");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("postal_code");

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentRound")
                        .HasColumnType("int")
                        .HasColumnName("current_round");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndInscriptionAt")
                        .HasColumnType("datetime")
                        .HasColumnName("end_inscription_at");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int")
                        .HasColumnName("max_players");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int")
                        .HasColumnName("min_players");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime")
                        .HasColumnName("start_at");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<int>("location_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("location_id");

                    b.ToTable("Tournament", (string)null);
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("avatar_url");

                    b.Property<DateOnly>("BirhDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<int>("Elo")
                        .HasColumnType("int")
                        .HasColumnName("elo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Utilisateur", (string)null);
                });

            modelBuilder.Entity("MM_Tournament_Category", b =>
                {
                    b.HasOne("Checkmate.Domain.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Checkmate.Domain.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("tournament_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Checkmate.Domain.Models.GameRoundPlayerTournament", b =>
                {
                    b.HasOne("Checkmate.Domain.Models.Utilisateur", "Black")
                        .WithMany("BlackMatches")
                        .HasForeignKey("black_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Checkmate.Domain.Models.Tournament", "Tournament")
                        .WithMany("Rounds")
                        .HasForeignKey("tournament_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Checkmate.Domain.Models.Utilisateur", "White")
                        .WithMany("WhiteMatches")
                        .HasForeignKey("white_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Black");

                    b.Navigation("Tournament");

                    b.Navigation("White");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.InscriptionPlayerTournament", b =>
                {
                    b.HasOne("Checkmate.Domain.Models.Utilisateur", "Player")
                        .WithMany("InscriptionPlayerTournaments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_InscriptionPlayerTournaments_Utilisateur");

                    b.HasOne("Checkmate.Domain.Models.Tournament", "Tournament")
                        .WithMany("InscriptionPlayerTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_InscriptionPlayerTournaments_Tournament");

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Tournament", b =>
                {
                    b.HasOne("Checkmate.Domain.Models.Location", "Location")
                        .WithMany("Tournaments")
                        .HasForeignKey("location_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Location", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Tournament", b =>
                {
                    b.Navigation("InscriptionPlayerTournaments");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("Checkmate.Domain.Models.Utilisateur", b =>
                {
                    b.Navigation("BlackMatches");

                    b.Navigation("InscriptionPlayerTournaments");

                    b.Navigation("WhiteMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
