using AnimeTracker.Database.DTO;

namespace AnimeTracker.Database.Repository;

public class ListSelfRepository
{
    private readonly ATDbContext _ctx = new();

    public ListSelfDTO? GetById(int id) => _ctx.ListSelf.Find(id);

    public List<ListSelfDTO>? GetByRange(int size, int page)
    {
        int minId = size * page + 1;
        int maxId = size * (page + 1);
        var animeList =  _ctx.ListSelf.Where(x => x.Id >= minId && x.Id <= maxId).ToList();

        AnimeRepository animeRepository = new();

        foreach (var anime in animeList)
        {
            anime.Anime = animeRepository.GetById((int)anime.AnimeId!);
        }

        return animeList;
    }

    public bool Add(ListSelfDTO dto)
    {
        AnimeRepository animeRepository = new();
        MovieRepository movieRepository = new();
        try
        {
            if (dto.AnimeId != null) dto.Anime = animeRepository.GetById((int)dto.AnimeId);
            if (dto.MovieId != null) dto.Movie = movieRepository.GetById((int)dto.MovieId);

            _ctx.Add(dto);
            _ctx.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(ListSelfUpdateDTO dto)
    {
        try
        {
            var oldDto = GetById(dto.Id);
            if (oldDto == null) return false;

            if (dto.AnimeId != null) oldDto.AnimeId = dto.AnimeId;
            if (dto.Anime != null) oldDto.Anime = dto.Anime;
            if (dto.MovieId != null) oldDto.Movie = dto.Movie;
            if (dto.Movie != null) oldDto.Movie = dto.Movie;
            if (dto.Watched != null) oldDto.Watched = (bool)dto.Watched;
            if (dto.Rating != null) oldDto.Rating = dto.Rating;

            _ctx.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Delete(int id)
    {
        _ctx.Remove(id);
        _ctx.SaveChanges();
    }
}
