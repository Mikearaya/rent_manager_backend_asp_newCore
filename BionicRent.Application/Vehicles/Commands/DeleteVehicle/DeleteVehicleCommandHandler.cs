using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.DeleteVehicle {
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeleteVehicleCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteVehicleCommand request, CancellationToken cancellationToken) {
            var vehicle = await _database.Vehicle.FindAsync (request.Id);

            if (vehicle == null) {
                throw new NotFoundException ($"Vehicle with id: {request.Id} Not found");
            }

            _database.Vehicle.Remove (vehicle);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}