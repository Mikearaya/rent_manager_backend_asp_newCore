/*
 * @CreateTime: Jan 25, 2019 11:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Roles.Models;
using BionicRent.Commons.QueryHelpers;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Roles.Queries.GetRolesList {
    public class GetRoleListViewQueryHandler : IRequestHandler<GetRoleListViewQuery, FilterResultModel<RoleViewModel>> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleListViewQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public Task<FilterResultModel<RoleViewModel>> Handle (GetRoleListViewQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Name";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RoleViewModel> result = new FilterResultModel<RoleViewModel> ();
            var vehicle = _roleManager.Roles
                .Select (RoleViewModel.ClaimLessProjection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<RoleViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                vehicle = vehicle
                    .Where (DynamicQueryHelper
                        .BuildWhere<RoleViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = vehicle.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = vehicle.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<RoleViewModel>> (result);
        }
    }
}