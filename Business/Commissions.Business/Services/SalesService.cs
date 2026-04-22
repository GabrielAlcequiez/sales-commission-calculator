using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Commissions.Business.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<Sales> _validator;
        private readonly ILogger<SalesService> _logger;

        public SalesService(
            ISalesRepository salesRepository,
            ICountryRepository countryRepository,
            IValidator<Sales> validator,
            ILogger<SalesService> logger)
        {
            _salesRepository = salesRepository;
            _countryRepository = countryRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Sales> CreateSaleAsync(Sales sale)
        {
            _logger.LogInformation("Iniciando el proceso de creación de venta.");
            var validationResult = await _validator.ValidateAsync(sale);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("La validación de la venta falló: {ValidationErrors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var country = await _countryRepository.GetById(sale.Id_Country);
            if (country == null || !country.IsActive)
            {
                _logger.LogWarning("País con ID {CountryId} no encontrado o inactivo.", sale.Id_Country);
                throw new InvalidOperationException("País no encontrado o inactivo.");
            }

            _logger.LogInformation("Cálculo de la comisión para la venta en el país {CountryName}.", country.Name);
            var baseAmount = sale.Total_Sales - sale.Discount;
            var commissionRate = country.Commission / 100m; 
            sale.Total_Commission = baseAmount * commissionRate;
            sale.CreatedAt = DateTime.UtcNow;

            await _salesRepository.AddAsync(sale);
            _logger.LogInformation("Venta creada con éxito con ID {SaleId}.", sale.Id);
            return sale;
        }

        public async Task<IReadOnlyList<Sales>> GetAllSalesAsync()
        {
            _logger.LogInformation("Obteniendo todas las ventas.");
            return await _salesRepository.GetAllAsync();
        }

        public async Task<Sales> GetSaleByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo venta por ID: {SaleId}", id);
            var sale = await _salesRepository.GetById(id);
            if (sale == null)
            {
                _logger.LogWarning("Venta con ID {SaleId} no encontrada.", id);
            }
            return sale;
        }
    }
}
