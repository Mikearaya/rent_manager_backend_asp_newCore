/*
 * @CreateTime: May 6, 2019 10:57 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:40 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicRent.Domain;

namespace BionicRent.Application.SystemLookups.Models {
    public class SystemLookupViewModel {
        public uint Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<SystemLookup, SystemLookupViewModel>> Projection {
            get {
                return lookup => new SystemLookupViewModel () {
                    Id = lookup.Id,
                    Type = lookup.Type,
                    Value = lookup.Value,
                    DateAdded = lookup.DateAdded,
                    DateUpdated = lookup.DateUpdated
                };
            }
        }
    }
}