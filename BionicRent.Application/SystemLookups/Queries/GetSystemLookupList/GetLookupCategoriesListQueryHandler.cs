/*
 * @CreateTime: May 12, 2019 2:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:43 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupCategoriesListQueryHandler : ApiQueryString, IRequestHandler<GetSystemLookupCategoriesListQuery, IEnumerable<SystemLookupCategoryIndexView>> {
        private readonly IBionicRentDatabaseService _database;

        public GetSystemLookupCategoriesListQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<SystemLookupCategoryIndexView>> Handle (GetSystemLookupCategoriesListQuery request, CancellationToken cancellationToken) {
            return await _database.SystemLookup
                .Where (l => l.Type.ToLower () == "system_lookup")
                .Select (SystemLookupCategoryIndexView.Project)
                .ToListAsync ();
        }
    }
}