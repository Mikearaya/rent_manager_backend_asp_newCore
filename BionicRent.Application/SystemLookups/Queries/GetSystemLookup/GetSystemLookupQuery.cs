/*
 * @CreateTime: May 6, 2019 11:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:41 AM
 * @Description: Modify Here, Please 
 */
using BionicRent.Application.SystemLookups.Models;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetSystemLookupQuery
        : IRequest<SystemLookupViewModel> {
            public int Id { get; set; }
        }
}