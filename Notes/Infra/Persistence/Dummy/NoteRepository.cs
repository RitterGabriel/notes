using Notes.Domain.Note;

namespace Notes.Infra.Persistence.Dummy;

public class NoteRepository : INoteRepository
{
    private static readonly List<NoteSpace> NotesSpaces = [];
    private static int _nextNoteId = 1;
    private static int _nextNoteSpaceId = 1;
    
    public async Task Add(Note note, string noteSpaceSlug)
    {
        var space = NotesSpaces.FirstOrDefault(space => space.Slug == noteSpaceSlug);
        note.Id = _nextNoteId++;
        note.Slug = Guid.NewGuid().ToString();
        space?.Notes.Add(note);
    }

    public async Task AddNoteSpace(NoteSpace noteSpace)
    {
        noteSpace.Id = _nextNoteSpaceId++;
        NotesSpaces.Add(noteSpace);
    }

    public Task RemoveNote(int noteId)
    {
        throw new NotImplementedException();
    }

    public async Task<NoteSpace?> GetNoteSpaceBySlug(string slug)
    {
        return NotesSpaces.FirstOrDefault(noteSpace => noteSpace.Slug == slug);
    }
}