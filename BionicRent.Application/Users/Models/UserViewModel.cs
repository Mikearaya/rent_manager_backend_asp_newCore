using System.Linq;
/*
 * @CreateTime: Apr 26, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:55 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;

namespace BionicRent.Application.Users.Models {
    public class UserViewModel {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Projection {

            get {
                return user => new UserViewModel () {
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Id = user.Id,
                    Role = user.UserRoles.Select (r => r.Role.Name).FirstOrDefault (),
                    RoleId = user.UserRoles.Select (r => r.Role.Id).FirstOrDefault ()

                };
            }

        }

        public static UserViewModel Create (ApplicationUser user) {
            return Projection.Compile ().Invoke (user);
        }
    }
}