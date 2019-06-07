/*
 * @CreateTime: Jun 7, 2019 9:52 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:52 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class Customer {

        public Customer () {
            Rent = new HashSet<Rent> ();
        }

        public uint CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string MobileNumber { get; set; }
        public string OtherPhone { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public string DrivingLicenceId { get; set; }
        public string HotelName { get; set; }
        public string HotelPhone { get; set; }

        public virtual ICollection<Rent> Rent { get; set; }

    }
}