using AuthDemo.Persistence.Contexts;

namespace AuthDemo.Persistence.Repositories;

internal abstract class BaseRepository
{
    protected AuthDemoDbContext _context;

    protected BaseRepository(AuthDemoDbContext context)
    {
        _context = context;
    }
}
