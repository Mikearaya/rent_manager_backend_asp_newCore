/*
 * @CreateTime: Jul 8, 2019 3:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:49 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicRent.Application.Users.Commands.UpdateUser {
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand> {
        public UpdateUserCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.Email).EmailAddress ();
            RuleFor (x => x.RoleId).NotEmpty ().NotNull ();
        }
    }
}