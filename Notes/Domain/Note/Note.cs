namespace Notes.Domain.Note;

public class Note
{
    public int Id { get; set; }
    public string Slug { get; set; } = "";
    public required string Title { get; set; }
    public required string Description { get; set; }
}