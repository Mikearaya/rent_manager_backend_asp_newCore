/*
 * @CreateTime: Jun 28, 2019 3:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 10:44 AMM
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

namespace BionicRent.Application.Reports.Queries.GetList {
    public class GetRemainingPartnerPaymentsQueryHandler : IRequestHandler<GetRemainingPartnerPaymentsQuery, FilterResultModel<RemainingPartnerPaymentsModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetRemainingPartnerPaymentsQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<RemainingPartnerPaymentsModel>> Handle (GetRemainingPartnerPaymentsQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "PartnerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RemainingPartnerPaymentsModel> result = new FilterResultModel<RemainingPartnerPaymentsModel> ();
            var remaining = _database.Rent
                .Where (r => r.Vehicle.Owner != null)
                .Select (RemainingPartnerPaymentsModel.Projection)

                .Select (DynamicQueryHelper.GenerateSelectedColumns<RemainingPartnerPaymentsModel> (request.SelectedColumns))
                .GroupBy (e => new { e.PartnerName, e.PartnerId })
                .Select (t => new RemainingPartnerPaymentsModel () {
                    PartnerName = t.Key.PartnerName,
                        PartnerId = t.Key.PartnerId,
                        Amount = t.Sum (o => o.Amount),
                        PaidAmount = t.Sum (o => o.PaidAmount)
                })
                .Where (r => r.RemainingAmount > 0).AsQueryable ();

            if (request.Filter.Count () > 0) {
                remaining = remaining
                    .Where (DynamicQueryHelper
                        .BuildWhere<RemainingPartnerPaymentsModel> (request.Filter)).AsQueryable ();
            }

            result.Count = remaining.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = remaining.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<RemainingPartnerPaymentsModel>> (result);

        }
    }
}