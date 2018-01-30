using ContactManager.WEB.Models;
using FluentValidation;

namespace ContactManager.WEB.Configurations
{
    public class PersonModelValidator : AbstractValidator<PersonModel>
    {
        public PersonModelValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty().MaximumLength(255);
            RuleFor(p => p.LastName).NotEmpty().MaximumLength(255);
            RuleFor(p => p.Birth).NotEmpty();
            RuleFor(p => p.Gender).NotNull().IsInEnum();
            RuleFor(p => p.PersonNumber).NotEmpty().MaximumLength(13);
            RuleFor(p => p.Email).NotEmpty().EmailAddress().MaximumLength(255);
            RuleFor(p => p.Phone).Matches(@"^\+44\([0-9]{3}\)\s[0-9]{7}|\+44\([0-9]{4}\)\s[0-9]{6}|\+44\([0-9]{5}\)\s[0-9]{5}$").MaximumLength(100);
            RuleFor(p => p.Address).SetValidator(new AddressModelValidator());
        }
    }
}
