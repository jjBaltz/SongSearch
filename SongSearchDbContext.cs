using Microsoft.EntityFrameworkCore;
using SongSearch.Models;

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
            new Artist { ArtistId = 101, Name = "The Classic Crime", Age = 19, Bio = "The Classic Crime is an American rock band from Seattle, Washington, formed in 2004."},
            new Artist { ArtistId = 102, Name = "The Amazing Devil", Age = 7, Bio = "The Amazing Devil is a dramatic, lyrical alt-folk band formed by Joey Batey and Madeleine Hyland."},
            new Artist { ArtistId = 103, Name = "Bring Me The Horizon", Age = 19, Bio = "Bring Me the Horizon are a British rock band, formed in Sheffield in 2004."},
            new Artist { ArtistId = 104, Name = "Machine Gun Kelly", Age = 16, Bio = "Machine Gun Kelly is an American rapper, singer, songwriter, musician, and actor."},
            new Artist { ArtistId = 105, Name = "Harry Styles", Age = 13, Bio = "Is an English singer and actor. His musical career began in 2010 as part of a boy band, One Direction."}
        });
        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song { SongId = 2001, ArtistId = 102, Title = "Welly Boots", Album = "The Horror and The Wild", Length = "5:23"},
            new Song { SongId = 2002, ArtistId = 105, Title = "Late Night Talking", Album = "Harry's House", Length = "2:57"},
            new Song { SongId = 2003, ArtistId = 101, Title = "Salt in the Snow", Album = "The Silver Chord", Length = "5:34"},
            new Song { SongId = 2004, ArtistId = 103, Title = "Doomed", Album = "That's the Spirit", Length = "4:34"},
            new Song { SongId = 2005, ArtistId = 104, Title = "mainstream sellout", Album = "Mainstream Sellout", Length = "1:47"},
            new Song { SongId = 2006, ArtistId = 103, Title = "Dear Diary,", Album = "POST HUMAN: SURVIVAL HORROR", Length = "2:44"},
            new Song { SongId = 2007, ArtistId = 102, Title = "The Calling", Album = "Ruin", Length = "6:09"},
            new Song { SongId = 2008, ArtistId = 105, Title = "Canyon Moon", Album = "Fine Line", Length = "3:09"},
            new Song { SongId = 2009, ArtistId = 101, Title = "Black & White", Album = "How to be Human", Length = "5:15"},
            new Song { SongId = 2010, ArtistId = 104, Title = "Sex Drive", Album = "El Diablo", Length = "2:03"}
        });
    
        modelBuilder.Entity<Song_Genre>().HasData(new Song_Genre[]
        {
            new Song_Genre { Song_GenreId = 301, GenreId = 406, SongId = 2001},
            new Song_Genre { Song_GenreId = 302, GenreId = 403, SongId = 2002},
            new Song_Genre { Song_GenreId = 303, GenreId = 401, SongId = 2003},
            new Song_Genre { Song_GenreId = 304, GenreId = 402, SongId = 2004},
            new Song_Genre { Song_GenreId = 305, GenreId = 405, SongId = 2005},
            new Song_Genre { Song_GenreId = 306, GenreId = 402, SongId = 2006},
            new Song_Genre { Song_GenreId = 307, GenreId = 406, SongId = 2007},
            new Song_Genre { Song_GenreId = 308, GenreId = 403, SongId = 2008},
            new Song_Genre { Song_GenreId = 309, GenreId = 401, SongId = 2009},
            new Song_Genre { Song_GenreId = 310, GenreId = 404, SongId = 2010}
        });
    
        modelBuilder.Entity<Genre>().HasData(new Genre []
        {
            new Genre { GenreId = 401, Description = "Alternative Rock"},
            new Genre { GenreId = 402, Description = "Screamo"},
            new Genre { GenreId = 403, Description = "Pop"},
            new Genre { GenreId = 404, Description = "Hip Hop"},
            new Genre { GenreId = 405, Description = "Pop Punk"},
            new Genre { GenreId = 406, Description = "Alternative Folk"}
        });
    }
}

