using AnimeTracker.Commands;
using Cocona;

var builder = CoconaApp.CreateBuilder();

var app = builder.Build();

app.AddCommands<AnimeTrackerListCommands>();
app.AddCommands<AnimeTrackerCudCommands>();

app.Run();