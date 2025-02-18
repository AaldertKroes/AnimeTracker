namespace AnimeTracker.Database.DTO;

public class QueueTogetherDTO
{
    public int Id { get; set; }
    public required int QueueTogetherId { get; set; }
    public required ListTogetherDTO ListTogetherDTO { get; set; }
}
