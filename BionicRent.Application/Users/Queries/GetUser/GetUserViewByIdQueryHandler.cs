/*
 * @CreateTime: Apr 26, 2019 11:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 12:31 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicRent.Application.Exceptions;
using BionicRent.Application.Users.Models;
using BionicRent.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicRent.Application.Users.Queries.GetUser {
    public class GetUserViewByIdQueryHandler : IRequestHandler<GetUserViewByIdQuery, UserViewModel> {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserViewByIdQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<UserViewModel> Handle (GetUserViewByIdQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.Users
                .Select (UserViewModel.Projection)
                .FirstOrDefaultAsync (u => u.id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            return user;
        }
    }
}