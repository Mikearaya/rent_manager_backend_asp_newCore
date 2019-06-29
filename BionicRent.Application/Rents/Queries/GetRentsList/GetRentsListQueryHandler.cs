/*
 * @CreateTime: Jun 28, 2019 7:58 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 28, 2019 8:06 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.Rents.Models;
using BionicRent.Application.Vehicles.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Rents.Queries.GetRentsList {
    public class GetRentsListQueryHandler : IRequestHandler<GetRentsListQuery, FilterResultModel<RentListViewModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetRentsListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<RentListViewModel>> Handle (GetRentsListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RentListViewModel> result = new FilterResultModel<RentListViewModel> ();
            var rent = _database.Rent
                .Select (RentListViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<RentListViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                rent = rent
                    .Where (DynamicQueryHelper
                        .BuildWhere<RentListViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = rent.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = rent.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<RentListViewModel>> (result);
        }
    }
}