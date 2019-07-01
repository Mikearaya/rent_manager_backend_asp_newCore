using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.CustomerPayments.Models {
    public class UnpaidCustomerRentModel {
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

        public static Expression<Func<Rent, UnpaidCustomerRentModel>> Projection {
            get {
                return rent => new UnpaidCustomerRentModel () {
                    RentId = rent.RentId,
                    Amount = rent.RentedPrice * ((rent.ReturnDate != null) ? rent.ReturnDate.Value.Subtract (rent.StartDate).Days : DateTime.Now.Subtract (rent.StartDate).Days),
                    PaidAmount = rent.RentPaymentDetail.Where (r => r.Payment.Customer != null).Sum (r => (decimal?) r.PaymentAmount) ?? 0,
                    StartDate = rent.StartDate,
                    EndDate = (rent.ReturnDate == null) ? DateTime.Now : rent.ReturnDate.Value

                };
            }
        }
    }
}