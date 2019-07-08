/*
 * @CreateTime: Jan 25, 2019 11:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:25 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicRent.Application.Roles.Commands.CreateCommand {
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string> {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IBionicRentDatabaseService _database;

        public CreateRoleCommandHandler (RoleManager<ApplicationRole> roleManager, IBionicRentDatabaseService database) {
            _roleManager = roleManager;
            _database = database;
        }

        public async Task<string> Handle (CreateRoleCommand request, CancellationToken cancellationToken) {
            ApplicationRole role = new ApplicationRole () {
                Name = request.Name
            };

            var result = await _roleManager.CreateAsync (role);

            if (result.Succeeded) {
                foreach (var item in request.Claims) {
                    await _database.RoleClaims.AddAsync (new RoleClaims () {
                        RoleId = role.Id,
                            ClaimType = item.ClaimType,
                            ClaimValue = item.ClaimValue
                    });
                }

                await _database.SaveAsync ();
                return role.Id;

            }

            throw new Exception (result.Errors.ToString ());
        }
    }
}