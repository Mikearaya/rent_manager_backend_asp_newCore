/*
 * @CreateTime: Jun 8, 2019 6:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:35 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.Partners.Commands.DeletePartner {
    public class DeletePartnerCommandValidator : AbstractValidator<DeletePartnerCommand> {
        public DeletePartnerCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}