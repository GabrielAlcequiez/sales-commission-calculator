using Commissions.Business.Entities;
using Commissions.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Commissions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Country>>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Country>> GetCountryById(Guid id)
        {
            try
            {
                var country = await _countryRepository.GetById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}