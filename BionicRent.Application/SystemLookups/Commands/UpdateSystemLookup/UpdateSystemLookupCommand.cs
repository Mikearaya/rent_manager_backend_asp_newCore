/*
 * @CreateTime: May 6, 2019 11:13 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:45 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.SystemLookups.Models;
using MediatR;

namespace BionicRent.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommand : IRequest {
        public IEnumerable<UpdatedSystemLookupModel> Lookups { get; set; } = new List<UpdatedSystemLookupModel> ();
    }
}