/*
 * @CreateTime: Jul 11, 2019 3:22 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 4:21 PM
 * @Description: Modify Here, Please  
 */

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Application.Reports.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Reports.Queries {
    public class GetPartnersRentPaymentHistoryQueryHandler : IRequestHandler<GetPartnersRentPaymentHistoryQuery, FilterResultModel<PartnersRentPaymentHistoryModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnersRentPaymentHistoryQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PartnersRentPaymentHistoryModel>> Handle (GetPartnersRentPaymentHistoryQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "PartnerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PartnersRentPaymentHistoryModel> result = new FilterResultModel<PartnersRentPaymentHistoryModel> ();

            var history = _database.Rent
                .Select (PartnersRentPaymentHistoryModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PartnersRentPaymentHistoryModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                history = history
                    .Where (DynamicQueryHelper
                        .BuildWhere<PartnersRentPaymentHistoryModel> (request.Filter));

            }

            result.Count = history.Count ();
            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = history.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();
            return Task.FromResult<FilterResultModel<PartnersRentPaymentHistoryModel>> (result);
        }
    }
}