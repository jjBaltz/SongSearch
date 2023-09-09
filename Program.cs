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
    return db.Artists.Single(a => a.ArtistId == id);
});


app.Run();
