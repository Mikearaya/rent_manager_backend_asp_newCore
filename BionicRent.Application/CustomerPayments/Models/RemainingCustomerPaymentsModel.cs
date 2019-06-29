/*
 * @CreateTime: Jun 29, 2019 11:43 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:26 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.CustomerPayments.Models {
    public class RemainingCustomerPaymentsModel {
        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainingPayment {
            get {
                return Amount - PaidAmount;
            }
            set {

            }
        }

        public static Expression<Func<Rent, RemainingCustomerPaymentsModel>> Projection {
            get {
                return rent => new RemainingCustomerPaymentsModel () {
                    CustomerId = rent.Customer.CustomerId,
                    CustomerName = rent.Customer.CustomerName,
                    Amount = rent.RentedPrice * ((rent.ReturnDate == null) ? rent.ReturnDate.Value.Subtract (rent.StartDate).Days : DateTime.Now.Subtract (rent.StartDate).Days),
                    PaidAmount = rent.RentPaymentDetail.Where (r => r.Payment.Partner == null).Sum (r => (decimal?) r.PaymentAmount) ?? 0
                };
            }
        }

    }
}