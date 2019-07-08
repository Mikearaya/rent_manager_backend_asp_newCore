/*
 * @CreateTime: Jan 25, 2019 11:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:31 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Models;
using BionicRent.Application.Roles.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Roles.Queries.GetRolesList {
    public class GetRoleListViewQuery : ApiQueryString, IRequest<FilterResultModel<RoleViewModel>> {

    }
}