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
using AutoMapper;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Partners.Commands.CreatePartner {
    public class CreateParnterCommandHandler : IRequestHandler<CreatePartnerCommand, uint> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public CreateParnterCommandHandler (IBionicRentDatabaseService database) {
            _database = database;

            var config = new MapperConfiguration (c => {
                c.CreateMap<CreatePartnerCommand, VehicleOwner> ();
            });

            _Mapper = config.CreateMapper ();
        }

        public async Task<uint> Handle (CreatePartnerCommand request, CancellationToken cancellationToken) {

            VehicleOwner owner = _Mapper.Map<CreatePartnerCommand, VehicleOwner> (request);
            owner.DateAdded = DateTime.Now;
            owner.DateUpdated = DateTime.Now;

            _database.VehicleOwner.Add (owner);

            await _database.SaveAsync ();

            return owner.OwnerId;
        }
    }
}