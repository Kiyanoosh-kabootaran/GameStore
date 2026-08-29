using GameStore.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

const string GetGameEndPointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDTO> games = [
  new(
      1,
      "Street Fighter ||",
      "Fighting",
      19.99M,
      new DateOnly(1997, 7, 15)),

  new(
      2,
      "Final Fantasy VII Rebith",
      "RPG",
      69.99M,
      new DateOnly(2024, 2, 29)),

  new(
      3,
      "Astro Bot",
      "Platformer",
      59.99M,
      new DateOnly(2024, 9, 6)),
];

// GET /games
app.MapGet("/games",() => games);

// GET /games/1
app.MapGet("games/{id}", (int id) =>
{
   var game = games.Find(game => game.Id == id);

   return game is null ? Results.NoContent() : Results.Ok(game);
})
    .WithName(GetGameEndPointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDTO game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.Id}, game);
});

// PUT /games/1
app.MapPut("/games/{id}", (int id, UpdateGameDTO updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    {
       return Results.NotFound();
    }

    games[index] = new GameDTO(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );

    return Results.NoContent();
});

// DELTE /games/1
app.MapDelete("/games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});



app.Run();
