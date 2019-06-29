using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Rents.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Rents.Queries.GetRent {
    public class GetRentQueryHandler : IRequestHandler<GetRentQuery, RentViewModel> {
        private readonly IBionicRentDatabaseService _database;

        public GetRentQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<RentViewModel> Handle (GetRentQuery request, CancellationToken cancellationToken) {
            return await _database.Rent
                .Select (RentViewModel.Projection)
                .FirstOrDefaultAsync (r => r.Id == request.Id);
        }

    }
}