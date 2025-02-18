using AnimeTracker.Database.DTO;

namespace AnimeTracker.Database.Repository;

public class AnimeRepository
{
    private readonly ATDbContext _ctx = new();

    public AnimeDTO? GetById(int id) => _ctx.Anime.Find(id);

    public List<AnimeDTO>? GetByRange(int size, int page)
    {
        int minId = size * page + 1;
        int maxId = size * (page + 1);
        return _ctx.Anime.Where(x => x.Id >= minId && x.Id <= maxId).ToList();
    }

    public bool Add(AnimeDTO dto)
    {
        try
        {
            _ctx.Add(dto);
            _ctx.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(AnimeUpdateDTO dto)
    {
        try
        {
            var oldDto = GetById(dto.Id);
            if (oldDto == null) return false;
            
            if (dto.Title != null) oldDto.Title = dto.Title;
            if (dto.Description != null) oldDto.Description = dto.Description;

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
