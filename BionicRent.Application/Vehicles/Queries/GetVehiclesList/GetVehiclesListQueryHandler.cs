/*
 * @CreateTime: Jun 9, 2019 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 5:57 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.Vehicles.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Vehicles.Queries.GetVehiclesList {
    public class GetVehiclesListQueryHandler : IRequestHandler<GetVehiclesListQuery, FilterResultModel<VehicleViewModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetVehiclesListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<VehicleViewModel>> Handle (GetVehiclesListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "FirstName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<VehicleViewModel> result = new FilterResultModel<VehicleViewModel> ();
            var customer = _database.Vehicle
                .Select (VehicleViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<VehicleViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                customer = customer
                    .Where (DynamicQueryHelper
                        .BuildWhere<VehicleViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = customer.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = customer.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<VehicleViewModel>> (result);
        }
    }
}