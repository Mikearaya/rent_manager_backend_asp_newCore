using System;

namespace BionicRent.Domain {

    public partial class RentPaymentDetail {
        public uint Id { get; set; }
        public uint RentId { get; set; }
        public float PaymentAmount { get; set; }
        public uint PaymentId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual RentPayment Payment { get; set; }
        public virtual Rent Rent { get; set; }
    }
}