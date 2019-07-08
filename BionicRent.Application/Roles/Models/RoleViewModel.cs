using System.Linq;
/*
 * @CreateTime: Jan 4, 2019 9:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;

namespace BionicRent.Application.Roles.Models {
    public class RoleViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleClaimModel> Claims { get; set; } = new List<RoleClaimModel> ();

        public static Expression<Func<ApplicationRole, RoleViewModel>> Projection {
            get {
                return role => new RoleViewModel () {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = role.RoleClaims.AsQueryable ().Select (RoleClaimModel.Projection)

                };
            }
        }

        public static Expression<Func<ApplicationRole, RoleViewModel>> ClaimLessProjection {
            get {
                return role => new RoleViewModel () {
                    Id = role.Id,
                    Name = role.Name,

                };
            }
        }
    }
}