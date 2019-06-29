using System.Linq;
/*
 * @CreateTime: Jun 10, 2019 8:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 10, 2019 8:34 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Rents.Commands.UpdateRent {
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public UpdateRentCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateRentCommand request, CancellationToken cancellationToken) {
            var rent = await _database.Rent.Include (r => r.RentCondition).FirstOrDefaultAsync (i => i.RentId == request.Id);

            if (rent == null) {
                throw new NotFoundException ($"rent with id {request.Id} not found");
            }

            rent.DateUpdated = DateTime.Now;
            rent.CustomerId = request.CustomerId;
            rent.VehicleId = request.VehicleId;
            rent.RentedBy = request.RentedBy;
            rent.RentedPrice = request.RentedPrice;
            rent.StartDate = request.StartDate;
            rent.ReturnDate = request.ReturnDate;
            rent.OwnerRentingPrice = request.OwnerRentingPrice;
            rent.ColateralDeposit = request.ColateralDeposit;

            _database.Rent.Update (rent);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}