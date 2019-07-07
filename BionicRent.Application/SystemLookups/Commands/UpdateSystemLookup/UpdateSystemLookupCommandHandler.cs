/*
 * @CreateTime: May 6, 2019 11:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:39 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandHandler : IRequestHandler<UpdateSystemLookupCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public UpdateSystemLookupCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (c => {
                c.CreateMap<NewSystemLookupModel, SystemLookup> ();
            }).CreateMapper ();

        }

        public async Task<Unit> Handle (UpdateSystemLookupCommand request, CancellationToken cancellationToken) {

            var lookups = _Mapper.Map<IEnumerable<NewSystemLookupModel>, IEnumerable<SystemLookup>> (request.Lookups);

            _database.SystemLookup.UpdateRange (lookups);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}