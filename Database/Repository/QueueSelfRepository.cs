using AnimeTracker.Database.DTO;

namespace AnimeTracker.Database.Repository;

public class QueueSelfRepository
{
    private readonly ATDbContext _ctx = new();

    public QueueSelfDTO? GetById(int id) => _ctx.QueueSelf.Find(id);

    public List<QueueSelfDTO>? GetByRange(int size, int page)
    {
        int minId = size * page + 1;
        int maxId = size * (page + 1);
        var animeList = _ctx.QueueSelf.Where(x => x.Id >= minId && x.Id <= maxId).ToList();

        return animeList;
    }

    public bool Add(QueueSelfDTO dto)
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
}
