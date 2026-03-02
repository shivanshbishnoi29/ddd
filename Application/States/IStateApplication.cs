using Application.Dtos;

namespace Application.States;

public interface IStateApplication
{
    public Task AddState(CreateUpdateStateDto input);
    public Task UpdateState(int id, CreateUpdateStateDto input);
    public Task DeleteState(int id);
    public Task<StateDto> GetStateById(int id);
    public Task<List<StateDto>> GetAllStates();
}
