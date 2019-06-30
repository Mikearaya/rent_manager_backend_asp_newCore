/*
 * @CreateTime: Jun 29, 2019 4:27 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 4:38 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.CustomerPayments.Models {
    public class CustomerPaymentListModel {
        public uint Id { get; set; }
        public uint? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<RentPayment, CustomerPaymentListModel>> Projection {
            get {
                return payment => new CustomerPaymentListModel () {
                    Id = payment.Id,
                    CustomerId = payment.CustomerId,
                    CustomerName = payment.Customer.CustomerName,
                    PaidAmount = payment.RentPaymentDetail.Sum (e => (decimal?) e.PaymentAmount),
                    Date = payment.Date,
                    DateAdded = payment.DateAdded,
                    DateUpdated = payment.DateUpdated
                };
            }

        }

    }
}