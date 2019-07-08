/*
 * @CreateTime: Apr 26, 2019 11:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 8, 2019 3:56 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.interfaces;
using BionicRent.Application.Roles.Models;
using BionicRent.Application.Users.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Queries.GetUser {
    public class GetUserViewByIdQueryHandler : IRequestHandler<GetUserViewByIdQuery, UserViewModel> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBionicRentDatabaseService _roleM;

        public GetUserViewByIdQueryHandler (UserManager<ApplicationUser> userManager, IBionicRentDatabaseService rolem) {
            _userManager = userManager;
            _roleM = rolem;
        }

        public async Task<UserViewModel> Handle (GetUserViewByIdQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.Users
                .Select (UserViewModel.Projection)
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            return user;
        }
    }
}