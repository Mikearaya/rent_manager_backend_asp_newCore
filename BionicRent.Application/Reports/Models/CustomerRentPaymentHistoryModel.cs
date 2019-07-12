using System.Linq;
using System.Linq.Expressions;
/*
 * @CreateTime: Jul 11, 2019 2:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 4:37 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Domain;

namespace BionicRent.Application.Reports.Models {
    public class CustomerRentPaymentHistoryModel {
        public uint RentId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime? RentEnd { get; set; }
        public string Vehicle { get; set; }
        public string PlateNumber { get; set; }
        public IEnumerable<RentPaymentModel> Payments { get; set; } = new List<RentPaymentModel> ();

        public static Expression<Func<Rent, CustomerRentPaymentHistoryModel>> Projection {

            get {
                return rent => new CustomerRentPaymentHistoryModel () {

                    RentId = rent.RentId,
                    CustomerName = rent.Customer.CustomerName,
                    Payments = rent.RentPaymentDetail.AsQueryable ().Select (RentPaymentModel.Projection).AsQueryable (),
                    RentStart = rent.StartDate,
                    RentEnd = rent.ReturnDate,
                    Vehicle = $"{rent.Vehicle.Make} {rent.Vehicle.Model}",
                    PlateNumber = $"{rent.Vehicle.PlateCode} {rent.Vehicle.PlateNumber}",

                };
            }
        }
    }
}