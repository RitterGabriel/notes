namespace Notes.Domain.Note;

public interface INoteRepository
{
    public Task Add(Domain.Note.Note note, string noteSpaceSlug);
    public Task AddNoteSpace(NoteSpace noteSpace);
    public Task RemoveNote(string noteSlug);
    public Task<NoteSpace?> GetNoteSpaceBySlug(string slug);
    public Task ReplaceNote(string noteSlug, Note note);
}