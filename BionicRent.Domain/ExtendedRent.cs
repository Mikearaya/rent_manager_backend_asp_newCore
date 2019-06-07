/*
 * @CreateTime: Jun 7, 2019 9:53 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:53 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicRent.Domain {
    public class ExtendedRent {

        public uint ExtendedId { get; set; }
        public uint RentId { get; set; }
        public uint? RepeatedExtendId { get; set; }
        public int ExtendedDays { get; set; }
        public int RentedPrice { get; set; }
        public int? OwnerRentingPrice { get; set; }
        public DateTime ExtendedOn { get; set; }

        public virtual Rent Rent { get; set; }
        public virtual ExtendedRent RepeatedExtend { get; set; }
        public virtual ExtendedRent InverseRepeatedExtend { get; set; }
    }
}