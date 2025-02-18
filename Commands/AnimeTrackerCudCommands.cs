using AnimeTracker.Database.DTO;
using AnimeTracker.Database.Repository;
using Cocona;

namespace AnimeTracker.Commands;

public class AnimeTrackerCudCommands
{
    [Command("add-anime", Description = "Adds an anime to the list")]
    public void AddAnime(
        [Argument(Description = "Title of the anime you want to add.")] string title,
        [Argument(Description = "Description of the anime you want to add.")] string description
    )
    {
        AnimeRepository repository = new();
        AnimeDTO animeToAdd = new AnimeDTO
        {
            Title = title,
            Description = description
        };
        Console.WriteLine(
            repository.Add(animeToAdd)
                ? "Added anime succesfully."
                : "Could not add anime."
        );
    }

    [Command("update-anime")]
    public void UpdateAnime(
        [Option(Description = "Id of the anime you want to update.")] int id,
        [Option('t', Description = "New title of the anime.")] string? title,
        [Option('d', Description = "New description of the anime.")] string? description
    )
    {
        AnimeRepository repository = new();
        AnimeUpdateDTO animeToUpdate = new AnimeUpdateDTO
        {
            Id = id,
            Title = title,
            Description = description
        };
        Console.WriteLine(
            repository.Update(animeToUpdate)
                ? "Updated anime succesfully."
                : "Could not update anime."
        );
    }

    [Command("add-movie")]
    public void AddMovie()
    {
        throw new NotImplementedException();
    }

    [Command("update-movie")]
    public void UpdateMovie()
    {
        throw new NotImplementedException();
    }

    [Command("add-self")]
    public void AddAnimeSelf(
        [Option(Description = "Id of the anime you want to add.")] int? animeId,
        [Option(Description = "Id of the movie you want to add.")] int? movieId,
        [Option('w', Description = "Flag if you've watched the anime or movie.")] bool watched,
        [Option(Description = "The rating you give the anime or movie.")] float rating
    )
    {
        rating = ConvertRating(rating);
        if (animeId == movieId)
        {
            Console.WriteLine("Pick either an anime ID or a movie ID. Not neither or both.");
        }
        else
        {
            ListSelfRepository repository = new();
            ListSelfDTO listSelfToAdd = new ListSelfDTO
            {
                AnimeId = animeId,
                MovieId = movieId,
                Watched = watched,
                Rating = rating
            };
            Console.WriteLine(
                repository.Add(listSelfToAdd)
                    ? "Added to own list succesfully."
                    : "Could not add to own list."
            );
        }
    }

    [Command("add-together")]
    public void AddAnimeTogether(
        [Option(Description = "Id of the anime you want to add.")] int? animeId,
        [Option(Description = "Id of the movie you want to add.")] int? movieId,
        [Option(Description = "The people you want to watch with.")] string people,
        [Option('w', Description = "Flag if you've watched the anime or movie.")] bool watched,
        [Option(Description = "The rating you give the anime or movie.")] float rating
    )
    {
        rating = ConvertRating(rating);
        if (animeId == movieId)
        {
            Console.WriteLine("Pick either an anime ID or a movie ID. Not neither or both.");
        }
        else
        {
            ListTogetherRepository repository = new();
            ListTogetherDTO listTogetherToAdd = new ListTogetherDTO
            {
                AnimeId = animeId,
                MovieId = movieId,
                People = people,
                Watched = watched,
                Rating = rating
            };
            Console.WriteLine(
                repository.Add(listTogetherToAdd)
                    ? "Added to together list succesfully."
                    : "Could not add to together list."
            );
        }
    }

    [Ignore]
    private float ConvertRating(float rating)
    {
        float newRating = Math.Abs(rating);
        while (newRating > 10)
        {
            newRating /= 10;
        }
        return newRating;
    }
}
