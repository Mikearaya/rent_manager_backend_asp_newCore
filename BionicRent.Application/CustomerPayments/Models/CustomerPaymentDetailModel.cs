using System.Linq;
/*
 * @CreateTime: Jun 29, 2019 4:31 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 11:11 AMM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.CustomerPayments.Models {
    public class CustomerPaymentDetailModel {
        public uint Id { get; set; }
        public uint? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public IEnumerable<RentPaymentModel> PaymentDetails = new List<RentPaymentModel> ();

        public static Expression<Func<RentPayment, CustomerPaymentDetailModel>> Projection {
            get {
                return payment => new CustomerPaymentDetailModel () {
                    Id = payment.Id,
                    CustomerId = payment.CustomerId,
                    CustomerName = payment.Customer.CustomerName,
                    Date = payment.Date,
                    DateAdded = payment.DateAdded,
                    DateUpdated = payment.DateUpdated,
                    PaymentDetails = payment.RentPaymentDetail.AsQueryable ().Select (RentPaymentModel.Projection)

                };
            }
        }

    }
}