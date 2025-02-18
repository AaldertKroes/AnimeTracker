namespace AnimeTracker.Database.DTO;

public class AnimeUpdateDTO
{
    public required int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
