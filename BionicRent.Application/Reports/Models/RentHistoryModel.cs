using System.Linq.Expressions;
/*
 * @CreateTime: Jul 1, 2019 3:03 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 1, 2019 3:38 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using BionicRent.Domain;

namespace BionicRent.Application.Reports.Models {
    public class RentHistoryModel {
        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string VehiclePlateNo { get; set; }
        public string VehicleMake { get; set; }

        public decimal? RentedPrice { get; set; }
        public decimal? PaidAmount { get; set; }
        public string PaymentStatus {
            get {
                return RentedPrice == PaidAmount ? "Paid" : $"{ PaidAmount /RentedPrice  * 100 } % Paid";
            }
            set { }
        }

        public static Expression<Func<Rent, RentHistoryModel>> Projection {
            get {
                return rent => new RentHistoryModel () {
                    Id = rent.RentId,
                    CustomerName = rent.Customer.CustomerName,
                    StartDate = rent.StartDate,
                    EndDate = rent.ReturnDate,
                    Duration = (rent.ReturnDate == null) ? DateTime.Now.Subtract (rent.StartDate).Days : rent.ReturnDate.Value.Subtract (rent.StartDate).Days,
                    Status = (rent.ReturnDate == null || rent.ReturnDate.Value > DateTime.Now) ? "Active" : "Ended",
                    VehiclePlateNo = $"{rent.Vehicle.PlateCode}-{rent.Vehicle.PlateNumber}",
                    VehicleMake = rent.Vehicle.Make,
                    RentedPrice = rent.RentedPrice * ((rent.ReturnDate == null) ? DateTime.Now.Subtract (rent.StartDate).Days : rent.ReturnDate.Value.Subtract (rent.StartDate).Days),
                    PaidAmount = rent.RentPaymentDetail.Where (p => p.Payment.Customer != null).Sum (e => (decimal?) e.PaymentAmount)
                };
            }
        }
    }
}