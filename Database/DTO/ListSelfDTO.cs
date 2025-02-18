namespace AnimeTracker.Database.DTO;

public class ListSelfDTO
{
    public int Id { get; set; }
    public int? AnimeId { get; set; }
    public AnimeDTO? Anime { get; set; }
    public int? MovieId { get; set; }
    public MovieDTO? Movie { get; set; }
    public required bool Watched { get; set; }
    public float? Rating { get; set; }
}
