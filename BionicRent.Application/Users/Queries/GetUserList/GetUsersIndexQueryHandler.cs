/*
 * @CreateTime: Jul 8, 2019 4:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 4:21 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.interfaces;
using BionicRent.Application.Users.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Queries.GetUserList {
    public class GetUsersIndexQueryHandler : IRequestHandler<GetUsersIndexQuery, IEnumerable<UserIndexModel>> {
        private readonly IBionicRentDatabaseService _database;

        public GetUsersIndexQueryHandler (IBionicRentDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<UserIndexModel>> Handle (GetUsersIndexQuery request, CancellationToken cancellationToken) {
            return await _database.Users
                .Where (u => u.NormalizedUserName.StartsWith (request.SearchString.Trim ().ToUpper ()))
                .Select (UserIndexModel.Projection)
                .ToListAsync ();
        }
    }
}