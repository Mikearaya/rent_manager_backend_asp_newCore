using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Rents.Models {
    public class RentListViewModel {
        public uint Id { get; set; }
        public uint VehicleId { get; set; }
        public string Vehicle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Rent, RentListViewModel>> Projection {
            get {
                return rent => new RentListViewModel () {
                    Id = rent.RentId,
                    VehicleId = rent.VehicleId,
                    Vehicle = $"{rent.Vehicle.PlateCode}-{rent.Vehicle.PlateNumber}",
                    CustomerId = rent.CustomerId,
                    CustomerName = rent.Customer.CustomerName,
                    StartDate = rent.StartDate,
                    ReturnDate = rent.ReturnDate,
                    Status = rent.Status,
                    DateAdded = rent.DateAdded,
                    DateUpdated = rent.DateUpdated

                };
            }
        }
    }
}