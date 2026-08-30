using GameStore.Api.DTOs;
using GameStore.Api.Endpoints;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

var app = builder.Build();



app.MapGamesEndpoints();

app.Run();
