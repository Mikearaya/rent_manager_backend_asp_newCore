/*
 * @CreateTime: Jul 8, 2019 3:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:36 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicRent.Application.Users.Commands.CreateUser {
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidator () {
            RuleFor (x => x.FullName).NotEmpty ().NotNull ();
            RuleFor (x => x.Email).EmailAddress ();
            RuleFor (x => x.RoleId).NotEmpty ().NotNull ();
        }
    }
}