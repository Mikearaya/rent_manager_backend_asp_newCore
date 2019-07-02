using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;
/*
 * @CreateTime: Jul 1, 2019 3:46 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 4:14 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Reports.Models {
    public class PartnersRentHistoryModel {

        public uint Id { get; set; }
        public string PartnerName { get; set; }
        public string VehicleMake { get; set; }
        public string VehiclePlateNo { get; set; }
        public uint RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RentDuration { get; set; }
        public decimal RentAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainingAmount {
            get {
                return RentAmount - PaidAmount;
            }
            set { }
        }
        public string Status { get; set; }
        public string PaymentStatus {
            get {
                return RentAmount == PaidAmount ? "Paid" : $"{ PaidAmount / RentAmount  * 100 } % Paid";
            }
            set { }
        }

        public static Expression<Func<Rent, PartnersRentHistoryModel>> Projection {
            get {
                return rent => new PartnersRentHistoryModel () {
                    Id = rent.Vehicle.Owner.OwnerId,
                    PartnerName = rent.Vehicle.Owner.PartnerName,
                    RentId = rent.RentId,
                    StartDate = rent.StartDate,
                    VehicleMake = rent.Vehicle.Make,
                    VehiclePlateNo = $"{rent.Vehicle.PlateCode} - {rent.Vehicle.PlateNumber}",
                    Status = (rent.ReturnDate == null || rent.ReturnDate.Value > DateTime.Now) ? "Active" : "Ended",
                    RentDuration = (rent.ReturnDate == null) ? DateTime.Now.Subtract (rent.StartDate).Days : rent.ReturnDate.Value.Subtract (rent.StartDate).Days,
                    RentAmount = rent.OwnerRentingPrice * ((rent.ReturnDate == null) ? DateTime.Now.Subtract (rent.StartDate).Days : rent.ReturnDate.Value.Subtract (rent.StartDate).Days),
                    PaidAmount = rent.RentPaymentDetail.Where (r => r.Payment.Partner != null).Sum (e => (decimal?) e.PaymentAmount)
                };
            }
        }

    }
}