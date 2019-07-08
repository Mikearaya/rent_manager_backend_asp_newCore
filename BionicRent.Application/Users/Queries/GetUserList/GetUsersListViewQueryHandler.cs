/*
 * @CreateTime: Apr 26, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:56 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Users.Models;
using BionicRent.Commons.QueryHelpers;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Queries.GetUserList {
    public class GetUsersListViewQueryHandler : IRequestHandler<GetUsersListViewQuery, FilterResultModel<UserViewModel>> {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsersListViewQueryHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManager = userManager;
        }

        public Task<FilterResultModel<UserViewModel>> Handle (GetUsersListViewQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "UserName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<UserViewModel> result = new FilterResultModel<UserViewModel> ();
            var vehicle = _userManager.Users
                .Select (UserViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<UserViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                vehicle = vehicle
                    .Where (DynamicQueryHelper
                        .BuildWhere<UserViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = vehicle.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = vehicle.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<UserViewModel>> (result);
        }
    }
}