using System.ComponentModel.DataAnnotations;
namespace SongSearch.Models;

public class Song_Genre
{
    public int Id { get; set; }
    public int SongId { get; set; }
    public Song Song { get; set; }
    public int GenreId { get; set; }
}