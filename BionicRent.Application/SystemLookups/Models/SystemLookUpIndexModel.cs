/*
 * @CreateTime: May 6, 2019 10:54 AM
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
    public class SystemLookUpIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public static Expression<Func<SystemLookup, SystemLookUpIndexModel>> Projection {
            get {
                return lookup => new SystemLookUpIndexModel () {
                    Id = lookup.Id,
                    Name = lookup.Value,
                    Type = lookup.Type
                };
            }
        }
    }

}