using FluentValidation;
using MobileBank.Application.Customers;

namespace MobileBank.API.Infrastructure.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerRequestModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Identifier)
              .NotEmpty()
              .Length(11)
              .WithMessage("error")
              .Matches("^[0-9]+$");

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Age)
            .Must(x => x > 18)
            .WithMessage("error");


            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^9955\d{7}$").WithMessage("eeror");
        }
    }
}
