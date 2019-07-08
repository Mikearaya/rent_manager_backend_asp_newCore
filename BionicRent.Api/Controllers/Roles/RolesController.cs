/*
 * @CreateTime: Jan 25, 2019 11:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:23 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicRent.Application.Roles.Commands.CreateRole;
using BionicRent.Application.Roles.Commands.DeleteCommand;
using BionicRent.Application.Roles.Commands.UpdateCommand;
using BionicRent.Application.Roles.Models;
using BionicRent.Application.Roles.Queries.GetRole;
using BionicRent.Application.Roles.Queries.GetRolesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.API.Controllers.Securities.Roles {

    [Route ("api/system-roles")]
    [DisplayName ("User Role")]
    public class RolesController : Controller {
        private readonly IMediator _Mediator;

        public RolesController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        [DisplayName ("View system roles list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAllUserRoles () {
            var roles = await _Mediator.Send (new GetRoleListViewQuery ());
            return StatusCode (200, roles);

        }

        [HttpGet ("{id}")]
        [DisplayName ("View system role detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoleViewModel>> GetRoleById (string id) {
            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = id });
            return StatusCode (200, role);

        }

        [HttpGet ("list")]
        [AllowAnonymous]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public ActionResult GetSystemFunctionsList () {
            return StatusCode (200);
        }

        [HttpPost]
        [DisplayName ("Create role")]
        [ProducesResponseType (201)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoleViewModel>> Create ([FromBody] CreateRoleCommand newRole) {

            if (newRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (newRole);

            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = result });

            return StatusCode (201, role);
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update role")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateRole ([FromBody] UpdateRoleCommand updatedRole) {

            if (updatedRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (updatedRole);

            return StatusCode (204);
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete role")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteRole (string id) {

            var result = await _Mediator.Send (new DeleteRoleCommand () { Id = id });
            return StatusCode (204);
        }
    }
}