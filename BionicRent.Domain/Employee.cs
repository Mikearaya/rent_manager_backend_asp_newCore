/*
 * @CreateTime: Jun 7, 2019 9:55 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 9:56 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicRent.Domain {
    public class Employee {
        public Employee () {
            Rent = new HashSet<Rent> ();
        }

        public uint EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public string HouseNumber { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Rent> Rent { get; set; }

    }

}