/*
 * @CreateTime: Jun 8, 2019 4:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:48 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Customers.Models;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Customers.Queries.GetCustomer {
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomerQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerViewModel> Handle (GetCustomerQuery request, CancellationToken cancellationToken) {
            var customer = await _database.Customer
                .Select (CustomerViewModel.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.Id);

            if (customer == null) {
                throw new NotFoundException ($"Customer with id: {request.Id}  Not Found");
            }

            return customer;
        }
    }
}