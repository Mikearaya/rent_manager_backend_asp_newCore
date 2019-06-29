/*
 * @CreateTime: Jun 8, 2019 6:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 22, 2019 6:02 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.Partners.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Partners.Queries.GetPartnersList {
    public class GetPartnersListQueryHandler : IRequestHandler<GetPartnersListQuery, FilterResultModel<PartnerViewModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnersListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<FilterResultModel<PartnerViewModel>> Handle (GetPartnersListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "PartnerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PartnerViewModel> result = new FilterResultModel<PartnerViewModel> ();
            var customer = _database.VehicleOwner
                .Select (PartnerViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PartnerViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                customer = customer
                    .Where (DynamicQueryHelper
                        .BuildWhere<PartnerViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = customer.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = customer.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return result;
        }
    }
}