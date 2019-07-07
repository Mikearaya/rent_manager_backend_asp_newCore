/*
 * @CreateTime: Jun 26, 2019 7:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 26, 2019 7:53 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Customers.Models;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Customers.Queries.GetCustomerList {
    public class GetCustomersIndexQueryHandler : IRequestHandler<GetCustomersIndexQuery, IEnumerable<CustomerIndexModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomersIndexQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<CustomerIndexModel>> Handle (GetCustomersIndexQuery request, CancellationToken cancellationToken) {
            return await _database.Customer
                .Select (CustomerIndexModel.Projection)
                .Where (c => c.Name.ToUpper ().StartsWith (request.SearchString.ToUpper ()))
                .ToListAsync ();
        }
    }
}