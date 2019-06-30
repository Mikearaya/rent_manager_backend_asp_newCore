/*
 * @CreateTime: Jun 30, 2019 11:06 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 11:40 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.CustomerPayments.Queries.GetPaymentsList {
    public class GetUnpaidCustomerRentsQueryHandler : IRequestHandler<GetUnpaidCustomerRentsQuery, IEnumerable<UnpaidCustomerRentModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetUnpaidCustomerRentsQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<UnpaidCustomerRentModel>> Handle (GetUnpaidCustomerRentsQuery request, CancellationToken cancellationToken) {
            var remaining = _database.Rent
                .Where (r => r.CustomerId == request.CustomerId)
                .Select (UnpaidCustomerRentModel.Projection)
                .ToList ()
                .Where (r => r.RemainingAmount > 0)
                .ToList ();

            return Task.FromResult<IEnumerable<UnpaidCustomerRentModel>> (remaining);

        }
    }
}