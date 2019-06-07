/*
 * @CreateTime: Jun 7, 2019 9:54 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:54 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicRent.Domain {
    public class RentPayment {

        public uint PaymentId { get; set; }
        public uint RentId { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Rent Rent { get; set; }
    }
}