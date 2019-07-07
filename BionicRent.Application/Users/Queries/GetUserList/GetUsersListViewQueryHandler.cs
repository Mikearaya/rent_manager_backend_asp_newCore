/*
 * @CreateTime: Apr 26, 2019 11:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:32 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Users.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Queries.GetUserList {
    public class GetUsersListViewQueryHandler : IRequestHandler<GetUsersListViewQuery, IEnumerable<UserViewModel>> {
        private readonly UserManager<ApplicationUser> _userManger;

        public GetUsersListViewQueryHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManger = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> Handle (GetUsersListViewQuery request, CancellationToken cancellationToken) {
            return await _userManger.Users
                .Select (UserViewModel.Projection)
                .ToListAsync ();
        }
    }
}