/*
 * @CreateTime: Jun 29, 2019 4:40 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 5:07 PM
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
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.CustomerPayments.Queries.GetPaymentsList {
    public class GetCustomerPaymentsListQueryHandler : IRequestHandler<GetCustomerPaymentsListQuery, FilterResultModel<CustomerPaymentListModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomerPaymentsListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<FilterResultModel<CustomerPaymentListModel>> Handle (GetCustomerPaymentsListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Date";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<CustomerPaymentListModel> result = new FilterResultModel<CustomerPaymentListModel> ();

            var payments = _database.RentPayment
                .Where (r => r.Customer != null)
                .Select (CustomerPaymentListModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerPaymentListModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                payments = payments
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerPaymentListModel> (request.Filter)).AsQueryable ();
            }

            result.Count = payments.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = payments.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return result;

        }
    }
}