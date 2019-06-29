/*
 * @CreateTime: Jun 29, 2019 11:45 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 11:56 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Queries.GetList {
    public class GetRemainingCustomerPaymentsQueryHandler : IRequestHandler<GetRemainingCustomerPaymentsQuery, FilterResultModel<RemainingCustomerPaymentsModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetRemainingCustomerPaymentsQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<RemainingCustomerPaymentsModel>> Handle (GetRemainingCustomerPaymentsQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "CustomerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RemainingCustomerPaymentsModel> result = new FilterResultModel<RemainingCustomerPaymentsModel> ();
            var remaining = _database.Rent
                .Where (r => r.Vehicle.Owner != null)
                .Select (RemainingCustomerPaymentsModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<RemainingCustomerPaymentsModel> (request.SelectedColumns))
                .GroupBy (e => new { e.CustomerName, e.CustomerId })
                .Select (t => new RemainingCustomerPaymentsModel () {
                    CustomerName = t.Key.CustomerName,
                        CustomerId = t.Key.CustomerId,
                        Amount = t.Sum (o => o.Amount),
                        PaidAmount = t.Sum (o => o.PaidAmount)
                })
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                remaining = remaining
                    .Where (DynamicQueryHelper
                        .BuildWhere<RemainingCustomerPaymentsModel> (request.Filter));
            }

            result.Count = remaining.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = remaining.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<RemainingCustomerPaymentsModel>> (result);
        }
    }
}