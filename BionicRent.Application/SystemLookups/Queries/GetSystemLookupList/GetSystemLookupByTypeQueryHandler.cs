/*
 * @CreateTime: May 6, 2019 11:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:43 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Commons.QueryHelpers;
using MediatR;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookupList {
    public class GetSystemLookupByTypeQueryHandler : IRequestHandler<GetSystemLookupByTypeQuery, IEnumerable<SystemLookUpIndexModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetSystemLookupByTypeQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<SystemLookUpIndexModel>> Handle (GetSystemLookupByTypeQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookup
                .Where (c => c.Type.Trim ().ToLower ().Equals (request.Type.Trim ().ToLower ()) &&
                    c.Value.Trim ().ToLower ().StartsWith (request.SearchString.ToLower ().Trim ()))
                .Select (SystemLookUpIndexModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookUpIndexModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<SystemLookUpIndexModel>> (lookup);
        }
    }
}