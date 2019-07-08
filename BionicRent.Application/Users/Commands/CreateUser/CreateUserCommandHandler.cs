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
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Commands.CreateUser {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBionicRentDatabaseService _database;

        public CreateUserCommandHandler (
            UserManager<ApplicationUser> userManager,
            IBionicRentDatabaseService database
        ) {
            _userManager = userManager;
            _database = database;
        }

        public async Task<string> Handle (CreateUserCommand request, CancellationToken cancellationToken) {

            var userModel = new ApplicationUser () {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = "000000",
            };

            var role = await _database.Roles.FindAsync (request.RoleId);

            if (role == null) {
                throw new NotFoundException ("Role", request.RoleId);
            }

            var result = await _userManager.CreateAsync (userModel, "000000");
            _database.UserRoles.Add (new UserRoles () {
                UserId = userModel.Id,
                    RoleId = role.Id
            });

            await _database.SaveAsync ();

            return userModel.Id;

        }
    }
}