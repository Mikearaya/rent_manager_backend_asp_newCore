/*
 * @CreateTime: May 6, 2019 11:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:38 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommandHandler : IRequestHandler<DeleteSystemLookupCommand, Unit> {
        private readonly IBionicRentDatabaseService _database;

        public DeleteSystemLookupCommandHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteSystemLookupCommand request, CancellationToken cancellationToken) {
            List<ValidationFailure> validationFailures = new List<ValidationFailure> ();
            var lookup = await _database.SystemLookup
                .FindAsync (request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            _database.SystemLookup.Remove (lookup);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}