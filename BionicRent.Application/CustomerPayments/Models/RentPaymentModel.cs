using System;
using System.Linq.Expressions;
using BionicRent.Domain;

/*
 * @CreateTime: Jun 28, 2019 2:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 6:21 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.CustomerPayments.Models {
    public class RentPaymentModel {

        public uint Id { get; set; }
        public uint RentId { get; set; }
        public float Amount { get; set; }
        public string Vehicle { get; set; }
        public string VehiclePlate { get; set; }
        public float TotalAmount { get; set; }
        public DateTime? Date { get; set; }

        public static Expression<Func<RentPaymentDetail, RentPaymentModel>> Projection {
            get {
                return payment => new RentPaymentModel () {
                    Id = payment.Id,
                    RentId = payment.RentId,
                    Amount = payment.PaymentAmount,
                    Date = payment.DateAdded
                };
            }
        }
    }
}