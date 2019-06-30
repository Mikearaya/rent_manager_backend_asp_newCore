/*
 * @CreateTime: Jun 29, 2019 4:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:26 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.CustomerPayments.Commands.DeleteCommand {
    public class DeleteCustomerPaymentCommandHandler : IRequestHandler<DeleteCustomerPaymentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeleteCustomerPaymentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerPaymentCommand request, CancellationToken cancellationToken) {
            var payment = await _database.RentPayment.FindAsync (request.Id);

            if (payment == null) {
                throw new NotFoundException ("Payment", request.Id);
            }

            _database.RentPayment.Remove (payment);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}