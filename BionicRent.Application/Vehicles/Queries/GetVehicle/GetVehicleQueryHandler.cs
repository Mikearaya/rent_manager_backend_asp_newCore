/*
 * @CreateTime: Jun 9, 2019 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 5:57 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.Vehicles.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Vehicles.Queries.GetVehicle {
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, VehicleViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetVehicleQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<VehicleViewModel> Handle (GetVehicleQuery request, CancellationToken cancellationToken) {
            var vehicle = await _database.Vehicle
                .Select (VehicleViewModel.Projection)
                .Where (v => v.Id == request.Id)
                .FirstOrDefaultAsync ();

            if (vehicle == null) {
                throw new NotFoundException ($"Vehicle with id : {request.Id} not found");
            }

            return vehicle;
        }
    }
}