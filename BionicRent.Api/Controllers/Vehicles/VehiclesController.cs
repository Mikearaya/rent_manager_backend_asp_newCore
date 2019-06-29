using System.Collections.Generic;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Vehicles.Commands.CreateVehicle;
using BionicRent.Application.Vehicles.Commands.DeleteVehicle;
using BionicRent.Application.Vehicles.Commands.UpdateVehicle;
using BionicRent.Application.Vehicles.Models;
using BionicRent.Application.Vehicles.Queries.GetVehicle;
using BionicRent.Application.Vehicles.Queries.GetVehiclesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Vehicles {

    [Route ("api/vehicles")]
    public class VehiclesController : Controller {
        private readonly IMediator _Mediator;

        public VehiclesController (IMediator mediator) {
            _Mediator = mediator;

        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<VehicleViewModel>> FindVehicleById (uint id) {
            var vehicle = await _Mediator.Send (new GetVehicleQuery () { Id = id });
            return Ok (vehicle);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<VehicleIndexModel>>> GetVehiclesIndex (uint id) {
            var vehicle = await _Mediator.Send (new GetVehiclesIndexQuery ());
            return Ok (vehicle);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<VehicleViewModel>>> GetVehiclesList ([FromBody] GetVehiclesListQuery query) {
            var vehiclesList = await _Mediator.Send (query);
            return Ok (vehiclesList);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleViewModel>> CreateVehicle ([FromBody] CreateVehicleCommand command) {
            var newId = await _Mediator.Send (command);
            var newVehicle = await _Mediator.Send (new GetVehicleQuery () { Id = newId });

            return StatusCode (201, newVehicle);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateVehicle ([FromBody] UpdateVehicleCommand command) {
            await _Mediator.Send (command);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteVehicle (uint id) {
            await _Mediator.Send (new DeleteVehicleCommand () { Id = id });
            return NoContent ();
        }
    }
}