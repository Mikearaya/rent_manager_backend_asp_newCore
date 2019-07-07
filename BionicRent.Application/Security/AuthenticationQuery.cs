/*
 * @CreateTime: Apr 26, 2019 10:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 5:58 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using BionicRent.Domain.Identity;
using MediatR;

namespace BionicRent.Application.Models {
    public class AuthenticationQuery : IRequest<ApplicationUser> {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}