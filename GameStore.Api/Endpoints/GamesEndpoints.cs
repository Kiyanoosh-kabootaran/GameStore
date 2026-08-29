using GameStore.Api.DTOs;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndPointName = "GetGame";
  private static readonly List<GameDTO> games = [
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

    public static void MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/games");
        
    // GET /games
    group.MapGet("/",() => games);

    // GET /games/1
    group.MapGet("/{id}", (int id) =>
    {
      var game = games.Find(game => game.Id == id);

      return game is null ? Results.NotFound() : Results.Ok(game);
    })
        .WithName(GetGameEndPointName);

    // POST /games
    group.MapPost("/", (CreateGameDto newGame) =>
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
    group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame) =>
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
    group.MapDelete("/{id}", (int id) =>
    {
        games.RemoveAll(game => game.Id == id);

        return Results.NoContent();
    });
      }
}