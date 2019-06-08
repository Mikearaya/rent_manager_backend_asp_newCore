using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Customers.Models;
using BionicRent.Application.interfaces;
using BionicRent.Application.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Customers.Queries.GetCustomerList {
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, FilterResultModel<CustomerViewModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomersListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<FilterResultModel<CustomerViewModel>> Handle (GetCustomersListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "FirstName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<CustomerViewModel> result = new FilterResultModel<CustomerViewModel> ();
            var customer = _database.Customer
                .Select (CustomerViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                customer = customer
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = customer.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = await customer.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToListAsync ();

            return result;

        }
    }
}