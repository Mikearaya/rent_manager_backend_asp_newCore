/*
 * @CreateTime: May 6, 2019 11:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:42 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.SystemLookups.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.SystemLookups.Queries.GetSystemLookup {
    public class GetSystemLookupQueryHandler : IRequestHandler<GetSystemLookupQuery, SystemLookupViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetSystemLookupQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<SystemLookupViewModel> Handle (GetSystemLookupQuery request, CancellationToken cancellationToken) {
            var lookup = await _database.SystemLookup
                .Select (SystemLookupViewModel.Projection)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            return lookup;

        }
    }
}