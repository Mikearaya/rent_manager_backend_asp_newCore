/*
 * @CreateTime: May 6, 2019 11:05 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:51 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicRent.Application.interfaces;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.SystemLookups.Commands.CreateSystemLookup {
    public class CreateSystemLookupCommandHandler : IRequestHandler<CreateSystemLookupCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;
        private IMapper _Mapper;

        public CreateSystemLookupCommandHandler (IBionicRentDatabaseService database) {
            _database = database;

            var config = new MapperConfiguration (c => {
                c.CreateMap<NewSystemLookupModel, SystemLookup> ();
            });

            _Mapper = config.CreateMapper ();
        }

        public async Task<Unit> Handle (CreateSystemLookupCommand request, CancellationToken cancellationToken) {

            IEnumerable<SystemLookup> lookups = _Mapper.Map<IEnumerable<NewSystemLookupModel>, IEnumerable<SystemLookup>> (request.Lookups);

            await _database.SystemLookup.AddRangeAsync (lookups);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}