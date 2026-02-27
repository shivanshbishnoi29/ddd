using Domain;

namespace Infrastructure.Repositories.Countries;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(Country country)
    {
        _context.Countries.Add(country);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var country= _context.Countries.Find(id);

        _context.Countries.Remove(country);
        _context.SaveChanges();
    }

    public List<Country> GetAll()
    {
        return _context.Countries.ToList();
    }

    public Country GetById(int id)
    {
        return _context.Countries.Find(id);
    }

    public void Update( Country country)
    {
        _context.Countries.Update(country);
        _context.SaveChanges();
    }
}
