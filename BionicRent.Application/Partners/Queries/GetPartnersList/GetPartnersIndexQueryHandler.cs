/*
 * @CreateTime: Jun 22, 2019 6:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 22, 2019 6:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Partners.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Partners.Queries.GetPartnersList {
    public class GetPartnersIndexQueryHandler : IRequestHandler<GetPartnersIndexQuery, IEnumerable<PartnersIndexModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetPartnersIndexQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<PartnersIndexModel>> Handle (GetPartnersIndexQuery request, CancellationToken cancellationToken) {
            return await _database.VehicleOwner.Select (PartnersIndexModel.Projection).ToListAsync ();
        }
    }
}