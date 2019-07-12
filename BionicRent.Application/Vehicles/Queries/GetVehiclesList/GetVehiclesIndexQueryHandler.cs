/*
 * @CreateTime: Jun 22, 2019 7:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 22, 2019 7:03 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Vehicles.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Vehicles.Queries.GetVehiclesList {
    public class GetVehiclesIndexQueryHandler : IRequestHandler<GetVehiclesIndexQuery, IEnumerable<VehicleIndexModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetVehiclesIndexQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VehicleIndexModel>> Handle (GetVehiclesIndexQuery request, CancellationToken cancellationToken) {
            return await _database
                .Vehicle
                .Select (VehicleIndexModel.Projection)
                .Where (e => e.PlateNumber.ToUpper ().StartsWith (request.SearchString.ToUpper ()))
                .ToListAsync ();
        }
    }
}