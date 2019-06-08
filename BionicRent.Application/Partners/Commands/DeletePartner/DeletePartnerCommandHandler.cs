/*
 * @CreateTime: Jun 8, 2019 6:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:39 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using MediatR;

namespace BionicRent.Application.Partners.Commands.DeletePartner {
    public class DeletePartnerCommandHandler : IRequestHandler<DeletePartnerCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeletePartnerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletePartnerCommand request, CancellationToken cancellationToken) {
            var owner = await _database.VehicleOwner.FindAsync (request.Id);

            if (owner == null) {
                throw new NotFoundException ($"Partner with id:  {request.Id}  Not found");
            }

            _database.VehicleOwner.Remove (owner);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}