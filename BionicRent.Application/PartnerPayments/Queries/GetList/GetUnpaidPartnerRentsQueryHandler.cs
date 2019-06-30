/*
 * @CreateTime: Jun 30, 2019 5:56 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 30, 2019 6:05 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.PartnerPayments.Models;
using MediatR;

namespace BionicRent.Application.PartnerPayments.Queries.GetList {
    public class GetUnpaidPartnerRentsQueryHandler : IRequestHandler<GetUnpaidPartnerRentsQuery, IEnumerable<UnpaidPartnerRentModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetUnpaidPartnerRentsQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<UnpaidPartnerRentModel>> Handle (GetUnpaidPartnerRentsQuery request, CancellationToken cancellationToken) {
            var remaining = _database.Rent
                .Where (r => r.Vehicle.OwnerId == request.PartnerId)
                .Select (UnpaidPartnerRentModel.Projection)
                .ToList ()
                .Where (r => r.RemainingAmount > 0)
                .ToList ();

            return Task.FromResult<IEnumerable<UnpaidPartnerRentModel>> (remaining);
        }
    }
}