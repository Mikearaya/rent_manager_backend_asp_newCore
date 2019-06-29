/*
 * @CreateTime: Jun 10, 2019 8:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Rents.Commands.DeleteRent {
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeleteRentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteRentCommand request, CancellationToken cancellationToken) {
            var rent = await _database.Rent.FindAsync (request.Id);

            if (rent == null) {
                throw new NotFoundException ($"Rent with id {request.Id} not found");
            }

            _database.Rent.Remove (rent);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}