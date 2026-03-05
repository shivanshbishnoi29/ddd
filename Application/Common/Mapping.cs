using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Common;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CreateUpdateStateDto, State>();
        CreateMap<State, StateDto>();
        CreateMap<Country, CountryDto>();


    }
}
