using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.PartnerPayments.Models {
    public class UnpaidPartnerRentModel {
        public uint RentId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? RemainingAmount {
            get {
                return Amount - PaidAmount;
            }
            set { }
        }
        public decimal? PaidAmount { get; set; }

        public static Expression<Func<Rent, UnpaidPartnerRentModel>> Projection {
            get {
                return rent => new UnpaidPartnerRentModel () {
                    RentId = rent.RentId,
                    Amount = rent.OwnerRentingPrice * ((rent.ReturnDate != null) ? rent.ReturnDate.Value.Subtract (rent.StartDate).Days : DateTime.Now.Subtract (rent.StartDate).Days),
                    PaidAmount = rent.RentPaymentDetail.Where (p => p.Payment.Partner != null).Sum (e => (decimal?) e.PaymentAmount) ?? 0,
                    StartDate = rent.StartDate,
                    EndDate = (rent.ReturnDate == null) ? DateTime.Now : rent.ReturnDate.Value

                };
            }
        }
    }
}