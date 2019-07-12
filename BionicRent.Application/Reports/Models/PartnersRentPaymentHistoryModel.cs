/*
 * @CreateTime: Jul 11, 2019 2:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 5:39 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicRent.Application.CustomerPayments.Models;
using BionicRent.Domain;

namespace BionicRent.Application.Reports.Models {
    public class PartnersRentPaymentHistoryModel {
        public uint RentId { get; set; }
        public string PartnerName { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime? RentEnd { get; set; }
        public string Vehicle { get; set; }
        public string PlateNumber { get; set; }
        public IEnumerable<RentPaymentModel> Payments { get; set; } = new List<RentPaymentModel> ();

        public static Expression<Func<Rent, PartnersRentPaymentHistoryModel>> Projection {

            get {
                return rent => new PartnersRentPaymentHistoryModel () {
                    RentId = rent.RentId,
                    PartnerName = rent.Vehicle.Owner.PartnerName,
                    RentStart = rent.StartDate,
                    RentEnd = rent.ReturnDate,
                    Vehicle = $"{rent.Vehicle.Make} {rent.Vehicle.Model}",
                    PlateNumber = $"{rent.Vehicle.PlateCode} {rent.Vehicle.PlateNumber}",
                    Payments = rent.RentPaymentDetail.Where (c => c.Payment != null).AsQueryable ().Select (RentPaymentModel.Projection)
                };
            }
        }
    }
}