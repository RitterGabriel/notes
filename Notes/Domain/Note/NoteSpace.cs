namespace Notes.Domain.Note;

public class NoteSpace
{
    public int Id { get; set; }
    public required string Slug { get; set; }
    public required List<Domain.Note.Note> Notes { get; set; }
}