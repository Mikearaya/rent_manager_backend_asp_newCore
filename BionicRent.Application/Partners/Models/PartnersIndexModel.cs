using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.Partners.Models {
    public class PartnersIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<VehicleOwner, PartnersIndexModel>> Projection {
            get {
                return owner => new PartnersIndexModel () {
                    Id = owner.OwnerId,
                    Name = owner.PartnerName
                };
            }
        }
    }
}