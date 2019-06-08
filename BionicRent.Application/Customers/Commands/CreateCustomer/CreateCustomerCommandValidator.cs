using FluentValidation;

namespace BionicRent.Application.Customers.Commands.CreateCustomer {
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand> {
        public CreateCustomerCommandValidator () {
            RuleFor (x => x.FirstName).NotEmpty ().NotNull ();
            RuleFor (x => x.MobileNumber).NotEmpty ().NotNull ();
            RuleFor (x => x.LastName).NotEmpty ().NotNull ();
            RuleFor (x => x.DrivingLicenceId).NotEmpty ().NotNull ();
        }
    }
}