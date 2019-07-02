/*
 * @CreateTime: Jul 1, 2019 4:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 4:15 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Reports.Queries {
    public class GetPartnersRentHistoryQueryHandler : IRequestHandler<GetPartnersRentHistoryQuery, FilterResultModel<PartnersRentHistoryModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnersRentHistoryQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PartnersRentHistoryModel>> Handle (GetPartnersRentHistoryQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "PartnerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PartnersRentHistoryModel> result = new FilterResultModel<PartnersRentHistoryModel> ();

            var history = _database.Rent
                .Where (v => v.Vehicle.Owner != null)
                .Select (PartnersRentHistoryModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PartnersRentHistoryModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                history = history
                    .Where (DynamicQueryHelper
                        .BuildWhere<PartnersRentHistoryModel> (request.Filter));
            }

            result.Count = history.Count ();
            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = history.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();
            return Task.FromResult<FilterResultModel<PartnersRentHistoryModel>> (result);
        }
    }
}