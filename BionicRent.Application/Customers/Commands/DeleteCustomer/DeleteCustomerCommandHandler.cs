/*
 * @CreateTime: Jun 8, 2019 4:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 4:37 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Customers.Commands.DeleteCustomer {
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeleteCustomerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerCommand request, CancellationToken cancellationToken) {
            var customer = await _database.Customer.FindAsync (request.Id);

            if (customer == null) {
                throw new NotFoundException ($"Customer with Id: {request.Id} Not found");
            }

            _database.Customer.Remove (customer);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}