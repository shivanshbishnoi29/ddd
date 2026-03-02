using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.States;

public class StateRepository : IStateRepository
{
    private readonly DataContext _context;

    public StateRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(State state)
    {
        await _context.States.AddAsync(state);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(State state)
    {
        _context.States.Remove(state);
        await _context.SaveChangesAsync();
    }

    public async Task<List<State>> GetAll()
    {
        return await _context.States.Include(x=>x.Country).ToListAsync();
    }

    public async Task<State?> GetById(int id)
    {
       return await _context.States.Include(x=>x.Country)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public Task Update(State state)
    {
        _context.States.Update(state);
        return _context.SaveChangesAsync();
    }
}
