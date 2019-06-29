/*
 * @CreateTime: Jun 28, 2019 9:46 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 28, 2019 9:52 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Rents.Models {
    public class RentViewModel {
        public uint Id { get; set; }
        public uint VehicleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public uint CustomerId { get; set; }
        public int OwnerRentingPrice { get; set; }
        public int RentedPrice { get; set; }
        public int ColateralDeposit { get; set; }
        public uint? RentedBy { get; set; }
        public VehicleConditionModel VehicleCondition { get; set; }

        public static Expression<Func<Rent, RentViewModel>> Projection {
            get {
                return rent => new RentViewModel () {
                    Id = rent.RentId,
                    VehicleId = rent.VehicleId,
                    StartDate = rent.StartDate,
                    ReturnDate = rent.ReturnDate,
                    CustomerId = rent.CustomerId,
                    OwnerRentingPrice = rent.OwnerRentingPrice,
                    RentedPrice = rent.RentedPrice,
                    ColateralDeposit = rent.ColateralDeposit,
                    RentedBy = rent.RentedBy,
                    VehicleCondition = rent.RentCondition.AsQueryable ()
                    .Select (VehicleConditionModel.Projection)
                    .FirstOrDefault ()
                };
            }
        }

    }
}