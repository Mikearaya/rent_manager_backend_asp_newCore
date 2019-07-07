/*
 * @CreateTime: Jan 25, 2019 11:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:29 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Roles.Models;
using MediatR;

namespace BionicRent.Application.Roles.Queries.GetRolesList {
    public class GetRoleListViewQuery : IRequest<IEnumerable<RoleViewModel>> {

    }
}