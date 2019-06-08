/*
 * @CreateTime: Jun 8, 2019 6:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:21 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.Partners.Commands.CreatePartner {
    public class CreatePartnerCommandValidator : AbstractValidator<CreatePartnerCommand> {
        public CreatePartnerCommandValidator () {

            RuleFor (x => x.FirstName).NotEmpty ().NotNull ();
            RuleFor (x => x.LastName).NotEmpty ().NotNull ();
            RuleFor (x => x.City).NotEmpty ().NotNull ();
            RuleFor (x => x.SubCity).NotEmpty ().NotNull ();
            RuleFor (x => x.Wereda).NotEmpty ().NotNull ();
            RuleFor (x => x.MobileNumber).NotEmpty ().NotNull ();
        }
    }
}