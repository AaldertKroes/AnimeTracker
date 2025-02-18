namespace AnimeTracker.Database.DTO;

public class MovieDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
