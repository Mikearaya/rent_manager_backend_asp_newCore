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