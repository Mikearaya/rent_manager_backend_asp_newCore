/*
 * @CreateTime: Jun 7, 2019 9:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:17 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class VehicleOwner {
        public VehicleOwner () {
            RentPayment = new HashSet<RentPayment> ();
            Vehicle = new HashSet<Vehicle> ();
        }

        public uint OwnerId { get; set; }
        public string PartnerName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string HouseNumber { get; set; }

        public virtual ICollection<RentPayment> RentPayment { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}