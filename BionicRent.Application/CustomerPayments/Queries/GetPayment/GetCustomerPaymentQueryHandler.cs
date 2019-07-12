using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.CustomerPayments.Queries.GetPayment {
    public class GetCustomerPaymentQueryHandler : IRequestHandler<GetCustomerPaymentQuery, CustomerPaymentDetailModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetCustomerPaymentQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerPaymentDetailModel> Handle (GetCustomerPaymentQuery request, CancellationToken cancellationToken) {
            var result = await _database.RentPayment
                .Where (p => p.Id == request.Id && p.Customer != null)
                .Select (CustomerPaymentDetailModel.Projection)
                .FirstOrDefaultAsync ();

            if (result == null) {
                throw new NotFoundException ("Customer Payment", request.Id);
            }

            return result;
        }
    }
}