using System.Linq;
/*
 * @CreateTime: Jan 4, 2019 9:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:40 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;

namespace BionicRent.Application.Roles.Models {
    public class RoleViewModel {
        public string id { get; set; }
        public string name { get; set; }
        public IEnumerable<RoleClaimModel> Claims { get; set; } = new List<RoleClaimModel> ();

        public static Expression<Func<ApplicationRole, RoleViewModel>> Projection {
            get {
                return role => new RoleViewModel () {
                    id = role.Id,
                    name = role.Name,
                    Claims = role.RoleClaims.AsQueryable ().Select (RoleClaimModel.Projection)

                };
            }
        }
    }
}