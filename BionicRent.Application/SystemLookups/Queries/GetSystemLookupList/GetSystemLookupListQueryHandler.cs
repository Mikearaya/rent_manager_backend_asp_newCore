/*
 * @CreateTime: May 6, 2019 11:38 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:44 AM
 * @Description: Modify Here, Please 
 */

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListQueryHandler : ApiQueryString, IRequestHandler<GetSystemLookupListQuery, FilterResultModel<SystemLookupViewModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetSystemLookupListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<SystemLookupViewModel>> Handle (GetSystemLookupListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Type";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<SystemLookupViewModel> result = new FilterResultModel<SystemLookupViewModel> ();
            var lookup = _database.SystemLookup
                .Where (l => l.Type.ToLower () != "system_lookup")
                .Select (SystemLookupViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookupViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                lookup = lookup
                    .Where (DynamicQueryHelper
                        .BuildWhere<SystemLookupViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = lookup.Count ();

            result.Items = lookup.OrderBy (sortBy, sortDirection).Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<SystemLookupViewModel>> (result);
        }
    }
}