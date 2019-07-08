using System;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;
/*
 * @CreateTime: Jul 8, 2019 4:28 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:29 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Roles.Models {
    public class RoleIndexModel {

        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<ApplicationRole, RoleIndexModel>> Projection {
            get {
                return role => new RoleIndexModel () {
                    Id = role.Id,
                    Name = role.Name
                };
            }
        }
    }
}