using ContactManager.WEB.Models;
using FluentValidation;

namespace ContactManager.WEB.Configurations
{
    public class AddressModelValidator : AbstractValidator<AddressModel>
    {
        public AddressModelValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Country).NotEmpty().MaximumLength(255);
            RuleFor(p => p.Region).MaximumLength(50);
            RuleFor(p => p.Street).NotEmpty().MaximumLength(255);
            RuleFor(p => p.City).NotEmpty().MaximumLength(255);
            RuleFor(p => p.Postal).Matches(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})$").MaximumLength(10);
        }
    }
}
