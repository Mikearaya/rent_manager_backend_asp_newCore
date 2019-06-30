using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;
/*
 * @CreateTime: Jun 28, 2019 3:07 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 10:43 AMM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Reports.Models {
    public class RemainingPartnerPaymentsModel {
        public uint? PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainingAmount {
            get {
                return Amount - PaidAmount;
            }
            set {

            }
        }

        public static Expression<Func<Rent, RemainingPartnerPaymentsModel>> Projection {
            get {
                return rent => new RemainingPartnerPaymentsModel () {
                    PaidAmount = rent.RentPaymentDetail.Where (e => e.Payment.Partner != null).Sum (p => (decimal?) p.PaymentAmount) ?? 0,
                    PartnerName = rent.Vehicle.Owner.PartnerName,
                    PartnerId = rent.Vehicle.OwnerId,
                    Amount = rent.OwnerRentingPrice * ((rent.ReturnDate == null) ? DateTime.Now.Subtract (rent.StartDate).Days : rent.ReturnDate.Value.Subtract (rent.StartDate).Days)

                };
            }
        }

        /*       public static Expression<Func<IGrouping<uint, RemainingPartnerPaymentsModel>, RemainingPartnerPaymentsModel>> GroupProjection {

              } */
    }
}