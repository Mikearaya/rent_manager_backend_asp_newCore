/*
 * @CreateTime: Jun 29, 2019 5:05 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 5:08 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.PartnerPayments.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.PartnerPayments.Queries.GetList {
    public class GetPartnerPaymentListQueryHandler : IRequestHandler<GetPartnerPaymentsListQuery, FilterResultModel<PartnerPaymentListModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnerPaymentListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<FilterResultModel<PartnerPaymentListModel>> Handle (GetPartnerPaymentsListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Date";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PartnerPaymentListModel> result = new FilterResultModel<PartnerPaymentListModel> ();

            var payments = _database.RentPayment
                .Where (r => r.Partner != null)
                .Select (PartnerPaymentListModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PartnerPaymentListModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                payments = payments
                    .Where (DynamicQueryHelper
                        .BuildWhere<PartnerPaymentListModel> (request.Filter)).AsQueryable ();
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