/*
 * @CreateTime: May 7, 2019 10:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:36 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace BionicRent.Application.SystemLookups.Commands.CreateSystemLookup {
    public class CreateSystemLookupCommandValidator : AbstractValidator<CreateSystemLookupCommand> {
        public CreateSystemLookupCommandValidator () {
            RuleForEach (x => x.Lookups).NotNull ();
        }
    }
}