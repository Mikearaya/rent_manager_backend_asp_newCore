/*
 * @CreateTime: Jul 1, 2019 3:16 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 3:26 PM
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
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Reports.Queries {
    public class GetRentHistoryQueryHandler : IRequestHandler<GetRentHistoryQuery, FilterResultModel<RentHistoryModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetRentHistoryQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<RentHistoryModel>> Handle (GetRentHistoryQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "StartDate";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RentHistoryModel> result = new FilterResultModel<RentHistoryModel> ();

            var history = _database.Rent
                .Select (RentHistoryModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<RentHistoryModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                history = history
                    .Where (DynamicQueryHelper
                        .BuildWhere<RentHistoryModel> (request.Filter));
            }

            result.Count = history.Count ();
            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = history.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();
            return Task.FromResult<FilterResultModel<RentHistoryModel>> (result);
        }
    }
}