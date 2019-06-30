/*
 * @CreateTime: Jun 28, 2019 2:38 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:07 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Commands.CreateCommand {
    public class AddCustomerPaymentCommandHandler : IRequestHandler<AddCustomerPaymentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public AddCustomerPaymentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (AddCustomerPaymentCommand request, CancellationToken cancellationToken) {

            var customer = await _database.Customer.FindAsync (request.CustomerId);

            if (customer == null) {
                throw new NotFoundException ("Customer", request.CustomerId);
            }

            RentPayment payment = new RentPayment () {
                CustomerId = request.CustomerId,
                Date = request.Date
            };

            foreach (var item in request.Rents) {
                payment.RentPaymentDetail.Add (new RentPaymentDetail () {
                    RentId = item.RentId,
                        PaymentAmount = item.Amount

                });
            }

            await _database.RentPayment.AddRangeAsync (payment);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}