/*
 * @CreateTime: Jun 8, 2019 6:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:48 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.Partners.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Partners.Queries.GetPartner {
    public class GetPartnerQueryHandler : IRequestHandler<GetPartnerQuery, PartnerViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnerQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<PartnerViewModel> Handle (GetPartnerQuery request, CancellationToken cancellationToken) {
            var owner = await _database.VehicleOwner
                .Select (PartnerViewModel.Projection)
                .Where (p => p.Id == request.Id)
                .FirstOrDefaultAsync ();

            if (owner == null) {
                throw new NotFoundException ($"Partner with id: {request.Id} not found");
            }

            return owner;
        }
    }
}