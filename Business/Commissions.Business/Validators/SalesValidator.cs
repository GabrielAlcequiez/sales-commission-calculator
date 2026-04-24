using Commissions.Domain.Entities;
using FluentValidation;

namespace Commissions.Business.Validators
{
    public class SalesValidator : AbstractValidator<Sales>
    {
        // Un poco de discrepancia en el documento, actualmente si estan integradas las validaciones
        public SalesValidator()
        {
            RuleFor(x => x.Total_Sales)
                .GreaterThan(0).WithMessage("Las ventas totales deben ser mayor a 0.");

            RuleFor(x => x.Discount)
                .LessThan(x => x.Total_Sales).WithMessage("El descuento no puede ser mayor a las ventas totales.");

            RuleFor(x => x.Id_Country)
                .NotEmpty().WithMessage("Pais es requerido.");
        }
    }
}
