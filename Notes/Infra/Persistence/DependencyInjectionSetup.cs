using Notes.Domain.Note;
using Notes.Infra.Persistence.Dummy;

namespace Notes.Infra.Persistence;

public static class DependencyInjectionSetup
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
    }
}