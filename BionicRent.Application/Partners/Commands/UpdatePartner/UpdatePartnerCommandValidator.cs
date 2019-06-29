using FluentValidation;

namespace BionicRent.Application.Partners.Commands.UpdatePartner {
    public class UpdatePartnerCommandValidator : AbstractValidator<UpdatePartnerCommand> {
        public UpdatePartnerCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.PartnerName).NotEmpty ().NotNull ();
            RuleFor (x => x.City).NotEmpty ().NotNull ();
            RuleFor (x => x.SubCity).NotEmpty ().NotNull ();
            RuleFor (x => x.Wereda).NotEmpty ().NotNull ();
            RuleFor (x => x.MobileNumber).NotEmpty ().NotNull ();
        }
    }
}