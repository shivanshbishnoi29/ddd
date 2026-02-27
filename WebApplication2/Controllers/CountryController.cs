using Application.Countries;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryApplication _countryApplication;

        public CountryController(ICountryApplication countryApplication)
        {
            _countryApplication = countryApplication;
        }

        [HttpPost]
        public void Create(CreateUpdateCountryDto input)
        {
            _countryApplication.Create(input);
        }

        [HttpGet("{id}")]
        public CountryDto GetById(int id)
        {
            return _countryApplication.GetById(id);
        }

        [HttpGet]
        public List<CountryDto> GetAll()
        {
            return _countryApplication.GetAll();
        }

        [HttpPut("{id}")]
        public void Update(int id, CreateUpdateCountryDto input)
        {
            _countryApplication.Update(id, input);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _countryApplication.Delete(id);
        }
    }
}
