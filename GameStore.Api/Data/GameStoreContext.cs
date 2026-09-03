using GameStore.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

#pragma warning disable CS9113 // Parameter is unread.
public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();
}