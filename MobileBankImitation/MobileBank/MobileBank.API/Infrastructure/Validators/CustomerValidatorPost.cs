using FluentValidation;
using MobileBank.Application.Customers;
using MobileBank.API.Infrastructure.Localizations;

namespace MobileBank.API.Infrastructure.Validators
{
    public class CustomerValidatorPost : AbstractValidator<CustomerRequestPostModel>
    {
        public CustomerValidatorPost()
        {
            RuleFor(x => x.Identifier)
              .NotEmpty()
              .Length(11)
              .WithMessage(ErrorMessages.IdentifierConstraint)
              .Matches("^[0-9]+$");

            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessages.EmailConstraint);

            RuleFor(x => x.Age)
            .Must(x => x > 18)
            .WithMessage(ErrorMessages.AgeError);


            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^9955\d{7}$").WithMessage(ErrorMessages.PhoneNumber);
        }
    }
}
