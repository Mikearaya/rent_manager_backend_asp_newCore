/*
 * @CreateTime: Jun 7, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 29, 2019 2:13 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class RentPayment {
        public RentPayment () {
            RentPaymentDetail = new HashSet<RentPaymentDetail> ();
        }

        public uint Id { get; set; }
        public uint? PartnerId { get; set; }
        public uint? CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual VehicleOwner Partner { get; set; }
        public virtual ICollection<RentPaymentDetail> RentPaymentDetail { get; set; }
    }
}