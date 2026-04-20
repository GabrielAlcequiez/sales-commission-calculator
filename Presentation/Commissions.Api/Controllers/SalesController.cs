using Commissions.Domain.Entities;
using Commissions.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commissions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        public async Task<ActionResult<Sales>> CreateSale([FromBody] Sales sale)
        {
            try
            {
                var createdSale = await _salesService.CreateSaleAsync(sale);
                return CreatedAtAction(nameof(GetSaleById), new { id = createdSale.Id }, createdSale);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Sales>>> GetAllSales()
        {
            var sales = await _salesService.GetAllSalesAsync();
            return Ok(sales);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Sales>> GetSaleById(Guid id)
        {
            try
            {
                var sale = await _salesService.GetSaleByIdAsync(id);
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}