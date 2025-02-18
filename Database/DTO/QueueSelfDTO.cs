namespace AnimeTracker.Database.DTO;

public class QueueSelfDTO
{
    public int Id { get; set; }
    public required int ListSelfId { get; set; }
    public required ListSelfDTO ListSelfDTO { get; set; }
}
