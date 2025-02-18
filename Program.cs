using AnimeTracker.Commands;
using Cocona;

var builder = CoconaApp.CreateBuilder();

var app = builder.Build();

app.AddCommands<AnimeTrackerCommands>();

app.Run();