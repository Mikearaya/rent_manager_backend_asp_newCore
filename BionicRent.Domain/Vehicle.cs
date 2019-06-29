/*
 * @CreateTime: Jun 7, 2019 9:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 10:58 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class Vehicle {
        public Vehicle () {
            Rent = new HashSet<Rent> ();
        }

        public uint VehicleId { get; set; }
        public uint? OwnerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string YearMade { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string ChassisNumber { get; set; }
        public string MotorNumber { get; set; }
        public string FuielType { get; set; }
        public string Cc { get; set; }
        public sbyte TotalPassanger { get; set; }
        public int? CylinderCount { get; set; }
        public string LibreNo { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string PlateCode { get; set; }
        public string PlateNumber { get; set; }
        public string Transmission { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual VehicleOwner Owner { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
    }
}