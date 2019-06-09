/*
 * @CreateTime: Jun 9, 2019 5:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 5:56 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Vehicles.Commands.UpdateVehicle {
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public UpdateVehicleCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
            var config = new MapperConfiguration (c => {
                c.CreateMap<UpdateVehicleCommand, Vehicle> ();
            });

            _Mapper = config.CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateVehicleCommand request, CancellationToken cancellationToken) {
            var vehicle = await _database.Vehicle.FindAsync (request.Id);

            if (vehicle == null) {
                throw new NotFoundException ($"Vehicle with id : {request.Id} not found");
            }

            _Mapper.Map (request, vehicle);

            _database.Vehicle.Update (vehicle);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}