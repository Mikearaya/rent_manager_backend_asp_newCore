using System;
/*
 * @CreateTime: Jun 8, 2019 6:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 8, 2019 7:03 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.Partners.Commands.UpdatePartner {
    public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        private IMapper _Mapper;

        public UpdatePartnerCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
            var config = new MapperConfiguration (c => {
                c.CreateMap<UpdatePartnerCommand, VehicleOwner> ();
            });

            _Mapper = config.CreateMapper ();
        }

        public async Task<Unit> Handle (UpdatePartnerCommand request, CancellationToken cancellationToken) {
            var owner = await _database.VehicleOwner.FindAsync (request.Id);

            if (owner == null) {
                throw new NotFoundException ($" Partner with id : {request.Id} Not found");
            }

            _Mapper.Map (request, owner);
            owner.UpdatedOn = DateTime.Now;

            _database.VehicleOwner.Update (owner);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}