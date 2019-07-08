using System.Linq;
/*
 * @CreateTime: Jul 8, 2019 4:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:38 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Roles.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Queries.GetRolesList {
    public class GetRoleIndexQueryHandler : IRequestHandler<GetRoleIndexQuery, IEnumerable<RoleIndexModel>> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleIndexQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleIndexModel>> Handle (GetRoleIndexQuery request, CancellationToken cancellationToken) {
            return await _roleManager.Roles
                .Where (r => r.NormalizedName.StartsWith (request.SearchString.Trim ().ToUpper ()))
                .Select (RoleIndexModel.Projection)
                .ToListAsync ();
        }
    }
}