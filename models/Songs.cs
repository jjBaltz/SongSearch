using System.ComponentModel.DataAnnotations;
namespace SongSearch.Models;

public class Song
{
    public int SongId { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; }
    public string Album { get; set; }
    public string Length { get; set; }
    public Artist Artist { get; set; }
    public Song_Genre Song_Genre { get; set; }
}