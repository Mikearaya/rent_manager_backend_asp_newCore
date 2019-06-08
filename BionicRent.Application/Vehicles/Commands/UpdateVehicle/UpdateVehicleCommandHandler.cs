using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.UpdateVehicle {
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public UpdateVehicleCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateVehicleCommand request, CancellationToken cancellationToken) {
            var vehicle = await _database.Vehicle.FindAsync (request.Id);

            if (vehicle == null) {
                throw new NotFoundException ($"Vehicle with id : {request.Id} not found");
            }

            vehicle.OwnerId = request.OwnerId;
            vehicle.Make = request.Make;
            vehicle.Model = request.Model;
            vehicle.MotorNumber = request.MotorNumber;
            vehicle.LibreNo = request.LibreNo;
            vehicle.PlateCode = request.PlateCode;
            vehicle.PlateNumber = request.PlateNumber;
            vehicle.Type = request.Type;
            vehicle.Transmission = request.Transmission;
            vehicle.TotalPassanger = request.TotalPassanger;
            vehicle.YearMade = request.YearMade;
            vehicle.ChassisNumber = request.ChassisNumber;
            vehicle.Color = request.Color;
            vehicle.Cc = request.Cc;
            vehicle.CylinderCount = request.CylinderCount;

            _database.Vehicle.Update (vehicle);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}