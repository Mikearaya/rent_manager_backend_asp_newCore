/*
 * @CreateTime: Jun 7, 2019 9:52 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 3:14 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class Customer {
        public Customer () {
            Rent = new HashSet<Rent> ();
            RentPayment = new HashSet<RentPayment> ();
        }

        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string MobileNumber { get; set; }
        public string OtherPhone { get; set; }
        public DateTime? DateAdded { get; set; }
        public string DrivingLicenceId { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<Rent> Rent { get; set; }
        public ICollection<RentPayment> RentPayment { get; set; }
    }
}