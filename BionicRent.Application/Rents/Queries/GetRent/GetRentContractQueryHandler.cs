/*
 * @CreateTime: Jul 10, 2019 9:21 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 9:24 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Rents.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Rents.Queries.GetRent {
    public class GetRentContractQueryHandler : IRequestHandler<GetRentContractQuery, RentContractView> {
        private readonly IBionicRentDatabaseService _database;

        public GetRentContractQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<RentContractView> Handle (GetRentContractQuery request, CancellationToken cancellationToken) {
            return await _database.Rent
                .Where (r => r.RentId == request.Id)
                .Select (RentContractView.Projection)
                .FirstOrDefaultAsync ();
        }
    }
}