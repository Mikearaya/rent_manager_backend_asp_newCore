/*
 * @CreateTime: Jun 8, 2019 6:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Partners.Models {
    public class PartnerViewModel {

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Wereda { get; set; }
        public string HouseNumber { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<VehicleOwner, PartnerViewModel>> Projection {
            get {
                return owner => new PartnerViewModel () {
                    Id = owner.OwnerId,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    HouseNumber = owner.HouseNumber,
                    MobileNumber = owner.MobileNumber,
                    City = owner.City,
                    SubCity = owner.SubCity,
                    Wereda = owner.Wereda,
                    DateAdded = owner.RegisteredOn,
                    DateUpdated = owner.UpdatedOn,
                };
            }
        }
    }
}