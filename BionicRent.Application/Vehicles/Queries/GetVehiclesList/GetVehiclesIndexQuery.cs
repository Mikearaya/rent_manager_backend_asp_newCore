using System.Collections.Generic;
using BionicRent.Application.Vehicles.Models;
using MediatR;

namespace BionicRent.Application.Vehicles.Queries.GetVehiclesList {
    public class GetVehiclesIndexQuery : IRequest<IEnumerable<VehicleIndexModel>> {
        public string PlateNumber { get; set; } = "";
    }
}