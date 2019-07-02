/*
 * @CreateTime: May 7, 2019 10:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:38 AMM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandValidator : AbstractValidator<DeleteSystemLookupCommand> {
        public DeleteSystemLookupCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }
    }
}