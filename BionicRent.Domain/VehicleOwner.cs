/*
 * @CreateTime: Jun 7, 2019 9:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:50 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class VehicleOwner {
        public VehicleOwner () {
            Vehicle = new HashSet<Vehicle> ();
        }

        public uint OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string HouseNumber { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}