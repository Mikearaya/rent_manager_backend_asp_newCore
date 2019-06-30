/*
 * @CreateTime: Jun 29, 2019 5:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 6:11 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.PartnerPayments.Models {
    public class PartnerPaymentListModel {
        public uint Id { get; set; }
        public uint? PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<RentPayment, PartnerPaymentListModel>> Projection {
            get {
                return payment => new PartnerPaymentListModel () {
                    Id = payment.Id,
                    PartnerId = payment.PartnerId,
                    PartnerName = payment.Partner.PartnerName,
                    PaidAmount = payment.RentPaymentDetail.Sum (e => (decimal?) e.PaymentAmount),
                    Date = payment.Date,
                    DateAdded = payment.DateAdded,
                    DateUpdated = payment.DateUpdated
                };
            }

        }
    }
}