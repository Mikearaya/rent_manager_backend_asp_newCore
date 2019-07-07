/*
 * @CreateTime: Jan 25, 2019 11:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:23 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Commands.UpdateCommand {
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UpdateRoleCommandHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle (UpdateRoleCommand request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            role.Name = request.Name;

            await _roleManager.UpdateAsync (role);

            return Unit.Value;

        }
    }
}