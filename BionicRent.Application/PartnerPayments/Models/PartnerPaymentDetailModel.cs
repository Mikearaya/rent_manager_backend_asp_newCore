/*
 * @CreateTime: Jul 11, 2019 6:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 6:24 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Domain;

namespace BionicRent.Application.PartnerPayments.Models {
    public class PartnerPaymentDetailModel {
        public uint Id { get; set; }
        public uint? PartnerId { get; set; }
        public string PartnerName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public IEnumerable<RentPaymentModel> PaymentDetails = new List<RentPaymentModel> ();

        public static Expression<Func<RentPayment, PartnerPaymentDetailModel>> Projection {
            get {
                return payment => new PartnerPaymentDetailModel () {
                    Id = payment.Id,
                    PartnerId = payment.PartnerId,
                    PartnerName = payment.Partner.PartnerName,
                    Date = payment.Date,
                    DateAdded = payment.DateAdded,
                    DateUpdated = payment.DateUpdated,
                    PaymentDetails = payment.RentPaymentDetail.AsQueryable ().Select (RentPaymentModel.Projection)

                };
            }
        }

    }
}