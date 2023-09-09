using SongSearch.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddNpgsql<SongSearchDbContext>(builder.Configuration["SongSearchDbConnectionString"]);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ARTIST ENDPOINTS
app.MapPost("/api/artists", (SongSearchDbContext db, Artist artist) =>
{
    try
    {
    db.Artists.Add(artist);
    db.SaveChanges();
    return Results.Created($"/api/artists/{artist.ArtistId}", artist);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/artists/{id}", (SongSearchDbContext db, int id) =>
{
    Artist artist = db.Artists.SingleOrDefault(artist => artist.ArtistId == id);
    if (artist == null)
    {
        return Results.NotFound();
    }
    db.Artists.Remove(artist);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/artists/{id}", (SongSearchDbContext db, int id, Artist artist) =>
{
    Artist artistToUpdate = db.Artists.SingleOrDefault(artist => artist.ArtistId == id);
    if (artistToUpdate == null)
    {
        return Results.NotFound();
    }
    artistToUpdate.Name = artist.Name;
    artistToUpdate.Age = artist.Age;
    artistToUpdate.Bio = artist.Bio;

    db.Update(artistToUpdate);
    db.SaveChanges();
    return Results.Ok(artistToUpdate);
});

app.MapGet("/api/artists", (SongSearchDbContext db) =>
{
    return db.Artists.ToList();
});

app.MapGet("/api/artists/{id}", (SongSearchDbContext db, int id) =>
{
    return db.Artists
        .Include(a => a.Songs)
        .Single(a => a.ArtistId == id);
});

//SONGS ENDPOINTS
app.MapPost("/api/songs", (SongSearchDbContext db, Song song) =>
{
    try
    {
        db.Songs.Add(song);
        db.SaveChanges();
        return Results.Created($"/api/songs/{song.SongId}", song);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/songs/{id}", (SongSearchDbContext db, int id) =>
{
    Song song = db.Songs.SingleOrDefault(song => song.SongId == id);
    if (song == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/songs/{id}", (SongSearchDbContext db, int id, Song song) =>
{
    Song songToUpdate = db.Songs.SingleOrDefault(song => song.SongId == id);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    songToUpdate.Title = song.Title;
    songToUpdate.Album = song.Album;
    songToUpdate.Length = song.Length;
    songToUpdate.ArtistId = song.ArtistId;

    db.Update(songToUpdate);
    db.SaveChanges();
    return Results.Ok(songToUpdate);
});

app.MapGet("/api/songs", (SongSearchDbContext db) =>
{
    return db.Songs.ToList();
});

app.MapGet("/api/songs/{id}", (SongSearchDbContext db, int id) =>
{
    return db.Songs
        .Include(song => song.Artist)
        .Include(song => song.Song_Genre)
        .Single(song => song.SongId == id);
});

//GENRE ENDPOINTS
app.MapPost("/api/genres", (SongSearchDbContext db, Genre genre) =>
{
    try
    {
        db.Genres.Add(genre);
        db.SaveChanges();
        return Results.Created($"/api/genres/{genre.GenreId}", genre);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/genres/{id}", (SongSearchDbContext db, int id) =>
{
    Genre genre = db.Genres.SingleOrDefault(genre => genre.GenreId == id);
    if (genre == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genre);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/genres/{id}", (SongSearchDbContext db, int id, Genre genre) =>
{
    Genre genreToUpdate = db.Genres.SingleOrDefault(genre => genre.GenreId == id);
    if (genreToUpdate == null)
    {
        return Results.NotFound();
    }
    genreToUpdate.Description = genre.Description;

    db.Update(genreToUpdate);
    db.SaveChanges();
    return Results.Ok(genreToUpdate);
});

app.MapGet("/api/genres", (SongSearchDbContext db) =>
{
    return db.Genres.ToList();
});

app.MapGet("/api/genres/{id}", (SongSearchDbContext db, int id) =>
{
    return db.Genres
        .Include(g => g.Songs)
        .Single(g => g.GenreId == id);
});

app.Run();
