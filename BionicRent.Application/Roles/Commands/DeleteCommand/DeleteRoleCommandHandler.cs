/*
 * @CreateTime: Jan 25, 2019 11:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:26 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Commands.DeleteCommand {
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DeleteRoleCommandHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle (DeleteRoleCommand request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            await _roleManager.DeleteAsync (role);

            return Unit.Value;

        }
    }
}