using AnimeTracker.Database.Repository;
using Cocona;

namespace AnimeTracker.Commands;

public class AnimeTrackerListCommands
{
    [Command("list", Description = "Shows the list of added anime.")]
    public void ListOfAnime(
        [Option(Description = "Controls the amount of records shown.")] int size = 20,
        [Option(Description = "Controls the page based on the size. (size 10, page 1) => 11-20.")] int page = 0
    )
    {
        AnimeRepository repository = new();
        var animeList = repository.GetByRange(size, page) ?? [];

        foreach (var currentAnime in animeList)
        {
            Console.WriteLine($"{currentAnime.Id} | {currentAnime.Title} | {currentAnime.Description}");
        }
    }

    [Command("list-movie")]
    public void ListOfMovies()
    {
        throw new NotImplementedException();
    }

    [Command("list-self", Description = "Shows the list of anime you want to watch yourself.")]
    public void ListOfAnimeSelf(
        [Option('q', Description = "Flag to show the queue or the entire list.")] bool queue,
        [Option(Description = "Controls the amount of records shown.")] int size = 20,
        [Option(Description = "Controls the page based on the size. (size 10, page 1) => 11-20.")] int page = 0
    )
    {
        if (queue)
        {
            QueueSelfRepository repository = new();
            throw new NotImplementedException();
        }
        else
        {
            ListSelfRepository repository = new();
            var animeList = repository.GetByRange(size, page) ?? [];

            foreach (var listItem in animeList)
            {
                string animeOrMovie = listItem.Anime != null
                    ? listItem.Anime!.Title
                    : listItem.Movie!.Title;
                string watched = listItem.Watched
                    ? "Watched"
                    : "Not watched";
                Console.WriteLine($"{listItem.Id} | {animeOrMovie} | {watched} | {listItem.Rating}/10");
            }
        }
    }

    [Command("list-together", Description = "Shows the list of anime you want to watch with people.")]
    public void ListOfAnimeTogether(
        [Option('q', Description = "Flag to show the queue or the entire list.")] bool queue,
        [Option(Description = "Controls the amount of records shown.")] int size = 20,
        [Option(Description = "Controls the page based on the size. (size 10, page 1) => 11-20.")] int page = 0
    )
    {
        if (queue)
        {
            QueueSelfRepository repository = new();
            throw new NotImplementedException();
        }
        else
        {
            ListTogetherRepository repository = new();
            var animeList = repository.GetByRange(size, page) ?? [];

            foreach (var listItem in animeList)
            {
                string animeOrMovie = listItem.Anime != null
                    ? listItem.Anime!.Title
                    : listItem.Movie!.Title;
                string watched = listItem.Watched
                    ? "Watched"
                    : "Not watched";
                Console.WriteLine($"{listItem.Id} | {listItem.People} | {animeOrMovie} | {watched} | {listItem.Rating}/10");
            }
        }
    }
}
