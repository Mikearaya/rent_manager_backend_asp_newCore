/*
 * @CreateTime: May 6, 2019 11:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:43 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupByTypeQuery : ApiQueryString, IRequest<IEnumerable<SystemLookUpIndexModel>> {
        public string Type { get; set; }
    }
}