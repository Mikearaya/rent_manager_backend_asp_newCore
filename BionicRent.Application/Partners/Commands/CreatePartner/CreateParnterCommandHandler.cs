using System;
/*
 * @CreateTime: Jun 8, 2019 6:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 6:25 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Partners.Commands.CreatePartner {
    public class CreateParnterCommandHandler : IRequestHandler<CreatePartnerCommand, uint> {
        private readonly IBionicRentDatabaseService _database;

        public CreateParnterCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (CreatePartnerCommand request, CancellationToken cancellationToken) {
            VehicleOwner owner = new VehicleOwner () {
                FirstName = request.FirstName,
                LastName = request.LastName,
                City = request.City,
                SubCity = request.SubCity,
                Wereda = request.Wereda,
                HouseNumber = request.HouseNumber,
                MobileNumber = request.MobileNumber,
                RegisteredOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };

            _database.VehicleOwner.Add (owner);

            await _database.SaveAsync ();

            return owner.OwnerId;
        }
    }
}