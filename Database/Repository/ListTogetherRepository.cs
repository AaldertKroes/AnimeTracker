using AnimeTracker.Database.DTO;

namespace AnimeTracker.Database.Repository;

public class ListTogetherRepository
{
    private readonly ATDbContext _ctx = new();

    public ListTogetherDTO? GetById(int id) => _ctx.ListTogether.Find(id);

    public List<ListTogetherDTO>? GetByRange(int size, int page)
    {
        int minId = size * page + 1;
        int maxId = size * (page + 1);
        var animeList = _ctx.ListTogether.Where(x => x.Id >= minId && x.Id <= maxId).ToList();

        AnimeRepository animeRepository = new();

        foreach (var anime in animeList)
        {
            anime.Anime = animeRepository.GetById((int)anime.AnimeId!);
        }

        return animeList;
    }

    public bool Add(ListTogetherDTO dto)
    {
        AnimeRepository animeRepository = new();
        try
        {
            if (dto.AnimeId != null) dto.Anime = animeRepository.GetById(dto.Id);
            //if (entity.MovieId != null) entity.MovieId = movieRepository.GetById(entity.Id);

            _ctx.Add(dto);
            _ctx.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
