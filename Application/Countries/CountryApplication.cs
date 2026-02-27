using Application.Dtos;
using Domain;
using Infrastructure.Repositories.Countries;

namespace Application.Countries;

public class CountryApplication : ICountryApplication
{
    private readonly ICountryRepository _countryRepository;

    public CountryApplication(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public void Create(CreateUpdateCountryDto input)
    {
        var country= new Country
        {
            Name = input.Name
        };

        _countryRepository.Add(country);
    }

    public void Delete(int id)
    {
        _countryRepository.Delete(id);
    }

    public List<CountryDto> GetAll()
    {
       var countries= _countryRepository.GetAll();

        var dtos= countries.Select(c => new CountryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();


        return dtos;
    }

    public CountryDto GetById(int id)
    {
        var country= _countryRepository.GetById(id);

       var dto= new CountryDto
        {
            Id = country.Id,
            Name = country.Name
        };

        return dto;
    }

    public void Update(int id, CreateUpdateCountryDto input)
    {
        var country= _countryRepository.GetById(id);
        country.Name = input.Name;

        _countryRepository.Update(country);
    }
}
