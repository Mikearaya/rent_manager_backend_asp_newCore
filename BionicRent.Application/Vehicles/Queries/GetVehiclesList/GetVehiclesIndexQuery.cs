using System.Collections.Generic;
using BionicRent.Application.Vehicles.Models;
using MediatR;

namespace BionicRent.Application.Vehicles.Queries.GetVehiclesList {
    public class GetVehiclesIndexQuery : IRequest<IEnumerable<VehicleIndexModel>> {
        private string PlateNumber { get; set; } = "";
        public string SearchString {
            get {
                return PlateNumber;
            }
            set {
                PlateNumber = (value == null) ? "" : value;
            }
        }
    }
}