using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Vehicles.Models {
    public class VehicleIndexModel {
        public uint Id { get; set; }
        public string PlateNumber { get; set; }

        public static Expression<Func<Vehicle, VehicleIndexModel>> Projection {
            get {
                return vehicle => new VehicleIndexModel () {
                    Id = vehicle.VehicleId,
                    PlateNumber = $"{vehicle.PlateCode}-{vehicle.PlateNumber}"
                };
            }
        }
    }
}