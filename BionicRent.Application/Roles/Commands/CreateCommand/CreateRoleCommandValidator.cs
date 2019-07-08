/*
 * @CreateTime: Jul 8, 2019 4:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:25 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicRent.Application.Roles.Commands.CreateCommand {
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand> {
        public CreateRoleCommandValidator () {
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
        }
    }
}