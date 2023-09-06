using Microsoft.EntityFrameworkCore;
using SongSearch.Models;
using System.Runtime.CompilerServices;

public class SongSearchDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Song_Genre> Song_Genres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public SongSearchDbContext(DbContextOptions<SongSearchDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist { Id = , Name = , Age = , Bio = , Songs = },
            new Artist { Id = , Name = , Age = , Bio = , Songs = },
            new Artist { Id = , Name = , Age = , Bio = , Songs = },
            new Artist { Id = , Name = , Age = , Bio = , Songs = },
            new Artist { Id = , Name = , Age = , Bio = , Songs = }
        });
        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = },
            new Song { Id = , ArtistId = , Title = , Album = , Length = }
        });
    
        modelBuilder.Entity<Song_Genre>().HasData(new Song_Genre[]
        {
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = },
            new Song_Genre { Id = , GenreId = , SongId = }
        });
    
        modelBuilder.Entity<Genre>().HasData(new Genre []
        {
            new Genre { Id = , Description = },
            new Genre { Id = , Description = },
            new Genre { Id = , Description = },
            new Genre { Id = , Description = },
            new Genre { Id = , Description = }
        });
    }
   
}

