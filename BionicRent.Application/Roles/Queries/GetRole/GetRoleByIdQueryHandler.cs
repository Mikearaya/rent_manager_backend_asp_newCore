/*
 * @CreateTime: Jan 25, 2019 11:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:57 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.Roles.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Queries.GetRole {
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleByIdQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<RoleViewModel> Handle (GetRoleByIdQuery request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .Where (r => r.Id == request.Id)
                .Select (RoleViewModel.Projection)
                .FirstOrDefaultAsync ();

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            return role;
        }
    }
}