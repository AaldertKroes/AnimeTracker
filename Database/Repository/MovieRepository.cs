using AnimeTracker.Database.DTO;

namespace AnimeTracker.Database.Repository;

public class MovieRepository
{
    private readonly ATDbContext _ctx = new();

    public MovieDTO? GetById(int id) => _ctx.Movies.Find(id);

    public List<MovieDTO>? GetByRange(int size, int page)
    {
        int minId = size * page + 1;
        int maxId = size * (page + 1);
        return _ctx.Movies.Where(x => x.Id >= minId && x.Id <= maxId).ToList();
    }

    public bool Add(MovieDTO dto)
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

    public bool Update(MovieUpdateDTO dto)
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
