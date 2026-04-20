using Commissions.Business.Entities;
using FluentValidation;

namespace Commissions.Business.Validators
{
public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
        .NotNull().WithMessage("Debe ingresar un nombre")
        .MaximumLength(20).WithMessage("El nombre es demasiado largo");

        RuleFor(c => c.Commission)
        .InclusiveBetween(0, 100)
        .WithMessage("La comisión debe estar entre 0 y 100%.");
    }
}
}