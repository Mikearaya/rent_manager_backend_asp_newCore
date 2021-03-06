﻿/*
 * @CreateTime: Jul 2, 2019 11:27 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 11, 2019 3:14 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public partial class SystemLookup {
        public SystemLookup () {
            VehicleColorNavigation = new HashSet<Vehicle> ();
            VehicleTypeNavigation = new HashSet<Vehicle> ();
        }

        public uint Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<Vehicle> VehicleColorNavigation { get; set; }
        public ICollection<Vehicle> VehicleTypeNavigation { get; set; }
    }
}