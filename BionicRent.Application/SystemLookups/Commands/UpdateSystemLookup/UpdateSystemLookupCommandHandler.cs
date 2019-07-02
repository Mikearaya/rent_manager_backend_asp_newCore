/*
 * @CreateTime: May 6, 2019 11:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:39 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Domain;
using MediatR;

namespace BionicRent.Application.SystemLookups.Commands.UpdateSystemLookup {
    public class UpdateSystemLookupCommandHandler : IRequestHandler<UpdateSystemLookupCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public UpdateSystemLookupCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateSystemLookupCommand request, CancellationToken cancellationToken) {

            foreach (var item in request.Lookups) {

                if (item.Id != 0) {
                    var look = await _database.SystemLookup.FindAsync (item.Id);

                    if (look == null) {
                        throw new NotFoundException ("System lookup", item.Id);
                    }
                    look.Type = item.Type;
                    look.Value = item.Value;
                    look.DateUpdated = DateTime.Now;
                    _database.SystemLookup.Update (look);

                } else {

                    _database.SystemLookup.Add (new SystemLookup () {
                        Type = item.Type,
                            Value = item.Value,
                            DateAdded = DateTime.Now,
                            DateUpdated = DateTime.Now
                    });
                }
            }

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}