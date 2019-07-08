/*
 * @CreateTime: Apr 26, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Models;
using BionicRent.Application.Users.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.Users.Queries.GetUserList {
    public class GetUsersListViewQuery : ApiQueryString, IRequest<FilterResultModel<UserViewModel>> {

    }
}