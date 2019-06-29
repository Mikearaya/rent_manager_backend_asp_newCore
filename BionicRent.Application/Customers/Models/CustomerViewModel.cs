using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Customers.Models {
    public class CustomerViewModel {

        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string MobileNumber { get; set; }
        public string OtherPhone { get; set; }
        public string DrivingLicenceId { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }

        public DateTime? DateAdded { get; set; }

        public static Expression<Func<Customer, CustomerViewModel>> Projection {
            get {
                return customer => new CustomerViewModel () {
                    Id = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    MobileNumber = customer.MobileNumber,
                    OtherPhone = customer.OtherPhone,
                    HotelName = customer.HotelName,
                    HotelPhone = customer.HotelPhone,
                    DrivingLicenceId = customer.DrivingLicenceId,
                    Nationality = customer.Nationality,
                    City = customer.City,
                    Country = customer.Country,
                    HouseNo = customer.HouseNo,
                    PassportNumber = customer.PassportNumber,
                    DateAdded = customer.DateAdded
                };
            }
        }
    }
}