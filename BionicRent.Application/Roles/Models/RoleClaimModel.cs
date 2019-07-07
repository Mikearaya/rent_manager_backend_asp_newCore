using System;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;
/*
 * @CreateTime: Jul 7, 2019 8:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:38 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Roles.Models {
    public class RoleClaimModel {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public static Expression<Func<RoleClaims, RoleClaimModel>> Projection {
            get {
                return claim => new RoleClaimModel () {
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue
                };
            }
        }
    }
}