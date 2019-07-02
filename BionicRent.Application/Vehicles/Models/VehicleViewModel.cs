using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Vehicles.Models {
    public class VehicleViewModel {

        public uint Id { get; set; }
        public uint? OwnerId { get; set; }
        public string Owner { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string YearMade { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string ChassisNumber { get; set; }
        public string MotorNumber { get; set; }
        public string FuielType { get; set; }
        public string Cc { get; set; }
        public sbyte TotalPassanger { get; set; }
        public int? CylinderCount { get; set; }
        public string LibreNo { get; set; }
        public string PlateCode { get; set; }
        public string PlateNumber { get; set; }
        public string Transmission { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Vehicle, VehicleViewModel>> Projection {
            get {
                return vehicle => new VehicleViewModel () {
                    Id = vehicle.VehicleId,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Cc = vehicle.Cc,
                    ChassisNumber = vehicle.ChassisNumber,
                    Color = vehicle.ColorNavigation.Value,
                    CylinderCount = vehicle.CylinderCount,
                    FuielType = vehicle.FuielType,
                    TotalPassanger = vehicle.TotalPassanger,
                    Transmission = vehicle.Transmission,
                    Type = vehicle.TypeNavigation.Value,
                    LibreNo = vehicle.LibreNo,
                    MotorNumber = vehicle.MotorNumber,
                    PlateCode = vehicle.PlateCode,
                    PlateNumber = vehicle.PlateNumber,
                    DateUpdated = vehicle.DateUpdated,
                    YearMade = vehicle.YearMade,
                    OwnerId = vehicle.OwnerId,
                    Owner = vehicle.Owner != null ? vehicle.Owner.PartnerName : "Company"
                };
            }
        }
    }
}