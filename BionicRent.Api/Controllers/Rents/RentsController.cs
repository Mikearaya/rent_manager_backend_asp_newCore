/*
 * @CreateTime: Jul 10, 2019 9:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 10, 2019 9:26 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Rents.Commands.CreateRent;
using BionicRent.Application.Rents.Commands.DeleteRent;
using BionicRent.Application.Rents.Commands.UpdateRent;
using BionicRent.Application.Rents.Models;
using BionicRent.Application.Rents.Queries.GetRent;
using BionicRent.Application.Rents.Queries.GetRentsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Rents {
    [Route ("api/vehicle-rent")]
    public class RentsController : Controller {
        private readonly IMediator _Mediator;

        public RentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<RentViewModel>> FindRentById (uint id) {
            var rent = await _Mediator.Send (new GetRentQuery () { Id = id });
            return Ok (rent);

        }

        [HttpGet ("{id}/contract")]
        public async Task<ActionResult<RentContractView>> GetRentContract (uint id) {
            var contract = await _Mediator.Send (new GetRentContractQuery () { Id = id });
            return StatusCode (200, contract);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<RentViewModel>>> GetRentsList ([FromBody] GetRentsListQuery query) {
            var rentsList = await _Mediator.Send (query);
            return Ok (rentsList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRent ([FromBody] CreateRentCommand command) {
            var mediator = await _Mediator.Send (command);
            return StatusCode (201, mediator);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateRent ([FromBody] UpdateRentCommand command) {
            await _Mediator.Send (command);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteRent ([FromBody] DeleteRentCommand command) {
            await _Mediator.Send (command);
            return NoContent ();
        }
    }
}