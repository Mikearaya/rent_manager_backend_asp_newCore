/*
 * @CreateTime: Jun 7, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:54 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class Rent {
        public Rent () {
            ExtendedRent = new HashSet<ExtendedRent> ();
            RentPayment = new HashSet<RentPayment> ();
            VehicleCondition = new HashSet<VehicleCondition> ();
        }

        public uint RentId { get; set; }
        public uint VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public uint CustomerId { get; set; }
        public int OwnerRentingPrice { get; set; }
        public int RentedPrice { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int ColateralDeposit { get; set; }
        public uint RentedBy { get; set; }
        public string Status { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee RentedByNavigation { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ExtendedRent> ExtendedRent { get; set; }
        public virtual ICollection<RentPayment> RentPayment { get; set; }
        public virtual ICollection<VehicleCondition> VehicleCondition { get; set; }
    }
}