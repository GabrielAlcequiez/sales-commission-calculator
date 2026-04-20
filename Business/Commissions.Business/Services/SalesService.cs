using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using FluentValidation;

namespace Commissions.Business.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IValidator<Sales> _validator;

        public SalesService(
            ISalesRepository salesRepository,
            ICountryRepository countryRepository,
            IValidator<Sales> validator)
        {
            _salesRepository = salesRepository;
            _countryRepository = countryRepository;
            _validator = validator;
        }

        public async Task<Sales> CreateSaleAsync(Sales sale)
        {
            var validationResult = await _validator.ValidateAsync(sale);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var country = await _countryRepository.GetById(sale.Id_Country);
            if (country == null || !country.IsActive)
            {
                throw new InvalidOperationException("País no encontrado o inactivo.");
            }

            var baseAmount = sale.Total_Sales - sale.Discount;
            sale.Total_Commission = baseAmount * country.Commission;
            sale.Id = Guid.CreateVersion7();
            sale.CreatedAt = DateTime.UtcNow;

            await _salesRepository.AddAsync(sale);
            return sale;
        }

        public async Task<IReadOnlyList<Sales>> GetAllSalesAsync()
        {
            return await _salesRepository.GetAllAsync();
        }

        public async Task<Sales> GetSaleByIdAsync(Guid id)
        {
            return await _salesRepository.GetById(id);
        }
    }
}