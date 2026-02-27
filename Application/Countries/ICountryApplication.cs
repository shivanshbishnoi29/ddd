using Application.Dtos;

namespace Application.Countries;

public interface ICountryApplication
{
    public void Create(CreateUpdateCountryDto input);
    public void Update(int id,CreateUpdateCountryDto input);
    public CountryDto GetById(int id);
    public List<CountryDto> GetAll();
    public void Delete(int id);

}
