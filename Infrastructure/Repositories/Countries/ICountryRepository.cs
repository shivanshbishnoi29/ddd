using Domain;

namespace Infrastructure.Repositories.Countries;

public interface ICountryRepository
{
    public void Add(Country country);
    public Country GetById(int id);
    public List<Country> GetAll();
    public void Update( Country country);
    public void Delete(int id);
}
