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
        public uint CustomerId { get; set; }
        public uint CustomerName { get; set; }
        public uint RentId { get; set; }
        public float PaidAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public IList<RentPaymentModel> PaymentDetails = new List<RentPaymentModel> ();

    }
}