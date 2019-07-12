/*
 * @CreateTime: Jul 11, 2019 2:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 4:21 PM
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
    public class GetCustomerRentPaymentsHistoryQueryHandler : IRequestHandler<GetCustomerRentPaymentsHistoryQuery, FilterResultModel<CustomerRentPaymentHistoryModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomerRentPaymentsHistoryQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<CustomerRentPaymentHistoryModel>> Handle (GetCustomerRentPaymentsHistoryQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "CustomerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<CustomerRentPaymentHistoryModel> result = new FilterResultModel<CustomerRentPaymentHistoryModel> ();

            var history = _database.Rent
                .Select (CustomerRentPaymentHistoryModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerRentPaymentHistoryModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                history = history
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerRentPaymentHistoryModel> (request.Filter));
            }

            result.Count = history.Count ();
            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = history.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();
            return Task.FromResult<FilterResultModel<CustomerRentPaymentHistoryModel>> (result);
        }
    }
}