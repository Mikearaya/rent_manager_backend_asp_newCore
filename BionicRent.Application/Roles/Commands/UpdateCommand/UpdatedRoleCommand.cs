/*
 * @CreateTime: Jan 25, 2019 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:27 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Roles.Models;
using MediatR;

namespace BionicRent.Application.Roles.Commands.UpdateCommand {
    public class UpdateRoleCommand : IRequest {

        public string Id { get; set; }
        public string Name { get; set; }

        public IList<RoleClaimModel> Claims { get; set; } = new List<RoleClaimModel> ();
    }
}