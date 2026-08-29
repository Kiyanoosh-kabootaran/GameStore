using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Game> games = [
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

// GET /game/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

app.Run();
