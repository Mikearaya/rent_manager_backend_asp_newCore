using System;
/*
 * @CreateTime: Jun 8, 2019 7:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:21 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.CreateVehicle {
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, uint> {
        private readonly IBionicRentDatabaseService _database;

        public CreateVehicleCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (CreateVehicleCommand request, CancellationToken cancellationToken) {

            var owner = await _database.VehicleOwner.FindAsync (request.OwnerId);

            if (owner == null) {
                throw new NotFoundException ($"Partner with id: {request.OwnerId} not foun");
            }
            Vehicle vehicle = new Vehicle () {
                Make = request.Make,
                Model = request.Model,
                Cc = request.Cc,
                ChassisNumber = request.ChassisNumber,
                Color = request.Color,
                CylinderCount = request.CylinderCount,
                FuielType = request.FuielType,
                TotalPassanger = request.TotalPassanger,
                Transmission = request.Transmission,
                Type = request.Type,
                LibreNo = request.LibreNo,
                MotorNumber = request.MotorNumber,
                PlateCode = request.PlateCode,
                PlateNumber = request.PlateNumber,
                UpdatedOn = DateTime.Now,
                YearMade = request.YearMade,
                OwnerId = request.OwnerId,
            };

            _database.Vehicle.Add (vehicle);
            await _database.SaveAsync ();

            return vehicle.VehicleId;

        }
    }
}