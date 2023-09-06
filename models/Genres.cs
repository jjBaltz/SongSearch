﻿using System.ComponentModel.DataAnnotations;
namespace SongSearch.Models;

public class Genre
{
    public int GenreId { get; set; }
    public string Description { get; set; }
    public List<Song> Songs { get; set; }
}