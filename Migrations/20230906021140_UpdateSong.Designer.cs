﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SongSearch.Migrations
{
    [DbContext(typeof(SongSearchDbContext))]
    [Migration("20230906021140_UpdateSong")]
    partial class UpdateSong
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SongSearch.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ArtistId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 101,
                            Age = 19,
                            Bio = "The Classic Crime is an American rock band from Seattle, Washington, formed in 2004.",
                            Name = "The Classic Crime"
                        },
                        new
                        {
                            ArtistId = 102,
                            Age = 7,
                            Bio = "The Amazing Devil is a dramatic, lyrical alt-folk band formed by Joey Batey and Madeleine Hyland.",
                            Name = "The Amazing Devil"
                        },
                        new
                        {
                            ArtistId = 103,
                            Age = 19,
                            Bio = "Bring Me the Horizon are a British rock band, formed in Sheffield in 2004.",
                            Name = "Bring Me The Horizon"
                        },
                        new
                        {
                            ArtistId = 104,
                            Age = 16,
                            Bio = "Machine Gun Kelly is an American rapper, singer, songwriter, musician, and actor.",
                            Name = "Machine Gun Kelly"
                        },
                        new
                        {
                            ArtistId = 105,
                            Age = 13,
                            Bio = "Is an English singer and actor. His musical career began in 2010 as part of a boy band, One Direction.",
                            Name = "Harry Styles"
                        });
                });

            modelBuilder.Entity("SongSearch.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 401,
                            Description = "Alternative Rock"
                        },
                        new
                        {
                            GenreId = 402,
                            Description = "Screamo"
                        },
                        new
                        {
                            GenreId = 403,
                            Description = "Pop"
                        },
                        new
                        {
                            GenreId = 404,
                            Description = "Hip Hop"
                        },
                        new
                        {
                            GenreId = 405,
                            Description = "Pop Punk"
                        },
                        new
                        {
                            GenreId = 406,
                            Description = "Alternative Folk"
                        });
                });

            modelBuilder.Entity("SongSearch.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SongId"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SongId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongId = 2001,
                            Album = "The Horror and The Wild",
                            ArtistId = 102,
                            Length = "5:23",
                            Title = "Welly Boots"
                        },
                        new
                        {
                            SongId = 2002,
                            Album = "Harry's House",
                            ArtistId = 105,
                            Length = "2:57",
                            Title = "Late Night Talking"
                        },
                        new
                        {
                            SongId = 2003,
                            Album = "The Silver Chord",
                            ArtistId = 101,
                            Length = "5:34",
                            Title = "Salt in the Snow"
                        },
                        new
                        {
                            SongId = 2004,
                            Album = "That's the Spirit",
                            ArtistId = 103,
                            Length = "4:34",
                            Title = "Doomed"
                        },
                        new
                        {
                            SongId = 2005,
                            Album = "Mainstream Sellout",
                            ArtistId = 104,
                            Length = "1:47",
                            Title = "mainstream sellout"
                        },
                        new
                        {
                            SongId = 2006,
                            Album = "POST HUMAN: SURVIVAL HORROR",
                            ArtistId = 103,
                            Length = "2:44",
                            Title = "Dear Diary,"
                        },
                        new
                        {
                            SongId = 2007,
                            Album = "Ruin",
                            ArtistId = 102,
                            Length = "6:09",
                            Title = "The Calling"
                        },
                        new
                        {
                            SongId = 2008,
                            Album = "Fine Line",
                            ArtistId = 105,
                            Length = "3:09",
                            Title = "Canyon Moon"
                        },
                        new
                        {
                            SongId = 2009,
                            Album = "How to be Human",
                            ArtistId = 101,
                            Length = "5:15",
                            Title = "Black & White"
                        },
                        new
                        {
                            SongId = 2010,
                            Album = "El Diablo",
                            ArtistId = 104,
                            Length = "2:03",
                            Title = "Sex Drive"
                        });
                });

            modelBuilder.Entity("SongSearch.Models.Song_Genre", b =>
                {
                    b.Property<int>("Song_GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Song_GenreId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("Song_GenreId");

                    b.HasIndex("SongId")
                        .IsUnique();

                    b.ToTable("Song_Genres");

                    b.HasData(
                        new
                        {
                            Song_GenreId = 301,
                            GenreId = 406,
                            SongId = 2001
                        },
                        new
                        {
                            Song_GenreId = 302,
                            GenreId = 403,
                            SongId = 2002
                        },
                        new
                        {
                            Song_GenreId = 303,
                            GenreId = 401,
                            SongId = 2003
                        },
                        new
                        {
                            Song_GenreId = 304,
                            GenreId = 402,
                            SongId = 2004
                        },
                        new
                        {
                            Song_GenreId = 305,
                            GenreId = 405,
                            SongId = 2005
                        },
                        new
                        {
                            Song_GenreId = 306,
                            GenreId = 402,
                            SongId = 2006
                        },
                        new
                        {
                            Song_GenreId = 307,
                            GenreId = 406,
                            SongId = 2007
                        },
                        new
                        {
                            Song_GenreId = 308,
                            GenreId = 403,
                            SongId = 2008
                        },
                        new
                        {
                            Song_GenreId = 309,
                            GenreId = 401,
                            SongId = 2009
                        },
                        new
                        {
                            Song_GenreId = 310,
                            GenreId = 404,
                            SongId = 2010
                        });
                });

            modelBuilder.Entity("SongSearch.Models.Song", b =>
                {
                    b.HasOne("SongSearch.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SongSearch.Models.Genre", null)
                        .WithMany("Songs")
                        .HasForeignKey("GenreId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("SongSearch.Models.Song_Genre", b =>
                {
                    b.HasOne("SongSearch.Models.Song", "Song")
                        .WithOne("Song_Genre")
                        .HasForeignKey("SongSearch.Models.Song_Genre", "SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("SongSearch.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SongSearch.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("SongSearch.Models.Song", b =>
                {
                    b.Navigation("Song_Genre")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}