/*
 * @CreateTime: Apr 26, 2019 12:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 10:04 AM
 * @Description: Modify Here, Please 
 */

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicRent.Application.Users.Commands.CreateUser {
    public class CreateUserCommand : IRequest<string> {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleId { get; set; }
        public string FullName { get; set; }

    }
}