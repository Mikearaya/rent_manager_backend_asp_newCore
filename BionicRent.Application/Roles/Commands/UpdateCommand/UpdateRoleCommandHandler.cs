/*
 * @CreateTime: Jan 25, 2019 11:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:38 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Commands.UpdateCommand {
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit> {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IBionicRentDatabaseService _database;
        public UpdateRoleCommandHandler (RoleManager<ApplicationRole> roleManager,
            IBionicRentDatabaseService database) {
            _roleManager = roleManager;
            _database = database;
        }

        public async Task<Unit> Handle (UpdateRoleCommand request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            role.Name = request.Name;

            var claims = _database.RoleClaims.Where (r => r.RoleId == role.Id).ToList ();

            _database.RoleClaims.RemoveRange (claims);

            foreach (var item in request.Claims) {
                _database.RoleClaims.Add (new RoleClaims () {
                    RoleId = role.Id,
                        ClaimType = item.ClaimType,
                        ClaimValue = item.ClaimValue
                });
            }

            await _roleManager.UpdateAsync (role);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}