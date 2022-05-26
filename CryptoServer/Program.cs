//using CryptoServer.Services;

using CryptoServer.Core;
using CryptoServer.DBContexts;
using CryptoServer.Interfaces;
using CryptoServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<Repository>();
builder.Services.AddGrpc();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CryptoService>();
app.Run();
