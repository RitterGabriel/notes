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

    public async Task RemoveNote(string noteSlug)
    {
        foreach (var noteSpace in NotesSpaces)
        {
            noteSpace.Notes = noteSpace.Notes.Where(note => note.Slug != noteSlug).ToList();
        }
    }

    public async Task<NoteSpace?> GetNoteSpaceBySlug(string slug)
    {
        return NotesSpaces.FirstOrDefault(noteSpace => noteSpace.Slug == slug);
    }

    public async Task ReplaceNote(string noteSlug, Note note)
    {
        foreach (var noteSpace in NotesSpaces)
        {
            var currentNote = noteSpace.Notes.FirstOrDefault(n => n.Slug == noteSlug);
            if (currentNote is null)
            {
                continue;
            }

            currentNote.Title = note.Title;
            currentNote.Description = note.Description;
            break;
        }
    }
}