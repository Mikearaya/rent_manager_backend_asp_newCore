using System.Security.Claims;
/*
 * @CreateTime: Jan 25, 2019 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:24 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using BionicRent.Application.Roles.Models;
using BionicRent.Domain.Identity;
using MediatR;

namespace BionicRent.Application.Roles.Commands.CreateCommand {
    public class CreateRoleCommand : IRequest<string> {
        public string Name { get; set; }

        public IEnumerable<RoleClaimModel> Claims = new List<RoleClaimModel> ();
    }
}