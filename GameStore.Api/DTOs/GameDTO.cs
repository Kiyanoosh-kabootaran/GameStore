// A DTO is a contract between client and the server since it represent
// a shared agreement about how data will be transferred and used

namespace GameStore.Api.DTOs
{
  public record Game(
    int Id ,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
    );
}