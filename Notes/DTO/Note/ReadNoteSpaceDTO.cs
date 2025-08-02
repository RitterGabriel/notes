namespace Notes.DTO.Note;

public class ReadNoteSpaceDto
{
    public required string Slug { get; set; }
    public required IEnumerable<ReadNoteDto> Notes { get; set; }
}

public class ReadNoteDto
{
    public required string Slug { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}