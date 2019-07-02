/*
 * @CreateTime: May 6, 2019 11:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:44 AM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.Models;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupListQuery : ApiQueryString, IRequest<FilterResultModel<SystemLookupViewModel>> { }
}