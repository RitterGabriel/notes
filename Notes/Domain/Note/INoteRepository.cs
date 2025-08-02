namespace Notes.Domain.Note;

public interface INoteRepository
{
    public Task Add(Domain.Note.Note note, string noteSpaceSlug);
    public Task AddNoteSpace(NoteSpace noteSpace);
    public Task RemoveNote(int noteId);
    public Task<NoteSpace?> GetNoteSpaceBySlug(string slug);
}