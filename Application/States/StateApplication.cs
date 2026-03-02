using Application.Dtos;
using Domain;
using Infrastructure.Repositories.Countries;
using Infrastructure.Repositories.States;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Application.States;

public class StateApplication : IStateApplication
{
    private readonly IStateRepository _stateReposiory;
    private readonly ICountryRepository _countryRepository;

    public StateApplication(IStateRepository stateReposiory, ICountryRepository countryRepository)
    {
        _stateReposiory = stateReposiory;
        _countryRepository = countryRepository;
    }


    public async Task AddState(CreateUpdateStateDto input)
    {
        var country = _countryRepository.GetById(input.CountryId);

        if (country == null)
        {
            return;
        }

        State state = new State
        {
            Name = input.Name,
            CountryId = input.CountryId,
        };

        await _stateReposiory.Create(state);
    }

    public async Task DeleteState(int id)
    {
        var state = await _stateReposiory.GetById(id);

        if (state == null)
        {
            return;
        }

        await _stateReposiory.Delete(state);
    }

    public async Task<List<StateDto>> GetAllStates()
    {
        var states = await _stateReposiory.GetAll();

        return states.Select(state=> new StateDto
        {
            Id=state.Id,
            Name = state.Name,
            CountryId = state.CountryId,
            Country= new CountryDto
            {
                Name=state.Country.Name,
                Id=state.CountryId,
            }
        }).ToList();
    }

    public async Task<StateDto> GetStateById(int id)
    {
        var state = await _stateReposiory.GetById(id);

        if(state==null)
        {
            return new StateDto();
        }

        return new StateDto
        {
            Id=state.Id,
            Name=state.Name,
            CountryId=state.CountryId,
            Country= new CountryDto
            {
                Name=state.Country.Name,
                Id=state.CountryId,
            }
        };
    }

    public async Task UpdateState(int id, CreateUpdateStateDto input)
    {
        var state = await _stateReposiory.GetById(id);
        if (state == null) 
        {
            return; 
        }

        var country = _countryRepository.GetById(input.CountryId);
        if (country == null)
        {
            return; 
        }

        state.Name=input.Name;
        state.CountryId=input.CountryId;

        await _stateReposiory.Update(state);
    }
}
