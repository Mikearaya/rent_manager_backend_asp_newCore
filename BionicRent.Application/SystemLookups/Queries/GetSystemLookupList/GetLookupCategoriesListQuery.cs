/*
 * @CreateTime: May 12, 2019 2:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:42 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupCategoriesListQuery : ApiQueryString, IRequest<IEnumerable<SystemLookupCategoryIndexView>> {

    }
}