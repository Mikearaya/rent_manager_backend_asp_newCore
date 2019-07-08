/*
 * @CreateTime: Jul 8, 2019 4:26 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:27 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicRent.Application.Roles.Commands.UpdateCommand {
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand> {
        public UpdateRoleCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
        }
    }
}