/*
 * @CreateTime: May 7, 2019 10:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:39 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandValidator : AbstractValidator<UpdateSystemLookupCommand> {
        public UpdateSystemLookupCommandValidator () {
            RuleFor (x => x.Lookups).NotNull ();
        }
    }
}