using System;
using System.Linq.Expressions;
using BionicRent.Domain.Identity;
/*
 * @CreateTime: Jul 8, 2019 4:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:06 PM
 * @Description: Modify Here, Please  
 */
namespace BionicRent.Application.Users.Models {
    public class UserIndexModel {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<ApplicationUser, UserIndexModel>> Projection {
            get {
                return user => new UserIndexModel () {
                    Id = user.Id,
                    Name = user.UserName,

                };
            }
        }
    }
}