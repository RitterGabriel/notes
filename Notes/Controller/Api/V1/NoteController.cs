using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Note;
using Notes.DTO.Note;

namespace Notes.Controller.Api.V1;

[ApiController]
[Route("api/v1/")]
public class NoteController(INoteRepository repository) : ControllerBase
{
    [HttpGet("notespaces/{noteSpaceSlug}")]
    public async Task<IActionResult> GetNoteSpace(string noteSpaceSlug)
    {
        var noteSpace = await repository.GetNoteSpaceBySlug(noteSpaceSlug);
        if (noteSpace is null)
        {
            return NotFound();
        }
        return Ok(new ReadNoteSpaceDto
        {
           Slug = noteSpace.Slug,
           Notes = noteSpace.Notes.Select(note => new ReadNoteDto
           {
               Slug = note.Slug,
               Title = note.Title,
               Description = note.Description,
               
           })
        });
    }

    [HttpPost("notespaces/")]
    public async Task<IActionResult> CreateNoteSpace([FromBody] CreateNoteSpaceDTO noteSpace)
    {
        await repository.AddNoteSpace(new NoteSpace
        {
            Slug = noteSpace.Slug,
            Notes = [],
        });
        
        return Created();
    }

    [HttpPost("notespaces/{noteSpaceSlug}/notes")]
    public async Task<IActionResult> CreateNote(string noteSpaceSlug, [FromBody] CreateNoteDto note)
    {
        await repository.Add(new Note
        {
            Title = note.Title,
            Description = note.Description,
        }, noteSpaceSlug);
        return Created();
    }
    
    [HttpDelete("notes/{noteSlug}")]
    public async Task<IActionResult> RemoveNote(string noteSlug)
    {
        await repository.RemoveNote(noteSlug);
        return Accepted();
    }

    [HttpPut("notes/{noteSlug}")]
    public async Task<IActionResult> EditNote(string noteSlug, [FromBody] EditNoteDto note)
    {
        await repository.ReplaceNote(noteSlug, new Note
        {
            Title = note.Title,
            Description = note.Description,
        });
        return NoContent();
    }

}