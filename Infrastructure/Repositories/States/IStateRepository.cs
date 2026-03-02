using Domain;

namespace Infrastructure.Repositories.States;

public interface IStateRepository
{
    public Task Create(State state);
    public Task<List<State>> GetAll();
    public Task Delete(State state);
    public Task<State?> GetById(int id);
    public Task Update(State state);
}
