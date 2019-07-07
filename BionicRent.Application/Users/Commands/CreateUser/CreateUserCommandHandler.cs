/*
 * @CreateTime: Apr 26, 2019 11:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 10:24 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicRent.Application.Users.Commands.CreateUser {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string> {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManager = userManager;
        }

        public async Task<string> Handle (CreateUserCommand request, CancellationToken cancellationToken) {

            var userModel = new ApplicationUser () {
                UserName = request.userName,
                PasswordHash = "000000",

            };
            var result = await _userManager.CreateAsync (userModel, "000000");

            return userModel.Id;

        }
    }
}