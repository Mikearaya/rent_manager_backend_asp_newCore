/*
 * @CreateTime: Jan 25, 2019 11:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:44 PM
 * @Description: Modify Here, Please 
 */

using BionicRent.Application.Roles.Models;
using MediatR;

namespace BionicRent.Application.Roles.Queries.GetRole {
    public class GetRoleByIdQuery : IRequest<RoleViewModel> {
        public string Id { get; set; }
    }
}