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
using AutoMapper;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.CreateVehicle {
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, uint> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;
        public CreateVehicleCommandHandler (IBionicRentDatabaseService database) {
            _database = database;

            var config = new MapperConfiguration (c => {
                c.CreateMap<CreateVehicleCommand, Vehicle> ();
            });
            _Mapper = config.CreateMapper ();
        }

        public async Task<uint> Handle (CreateVehicleCommand request, CancellationToken cancellationToken) {

            if (request.OwnerId != null) {
                var owner = await _database.VehicleOwner.FindAsync (request.OwnerId);

                if (owner == null) {
                    throw new NotFoundException ($"Partner with id: {request.OwnerId} not foun");
                }
            }

            Vehicle vehicle = _Mapper.Map<CreateVehicleCommand, Vehicle> (request);

            vehicle.DateUpdated = DateTime.Now;

            _database.Vehicle.Add (vehicle);

            await _database.SaveAsync ();

            return vehicle.VehicleId;

        }
    }
}