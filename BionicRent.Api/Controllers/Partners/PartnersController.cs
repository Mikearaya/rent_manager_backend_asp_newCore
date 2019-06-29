/*
 * @CreateTime: Jun 8, 2019 6:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 22, 2019 6:33 PMM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.Partners.Commands.CreatePartner;
using BionicRent.Application.Partners.Commands.DeletePartner;
using BionicRent.Application.Partners.Commands.UpdatePartner;
using BionicRent.Application.Partners.Models;
using BionicRent.Application.Partners.Queries.GetPartner;
using BionicRent.Application.Partners.Queries.GetPartnersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.Partners {

    [Route ("api/vehicle-owners")]
    public class PartnersController : Controller {
        private readonly IMediator _Mediator;

        public PartnersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<PartnerViewModel>> FindPartnerById (uint id) {
            var owner = await _Mediator.Send (new GetPartnerQuery () { Id = id });
            return Ok (owner);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<PartnersIndexModel>>> GetPartnersIndex () {
            var owner = await _Mediator.Send (new GetPartnersIndexQuery());
            return Ok (owner);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<PartnerViewModel>>> GetPartnersList ([FromBody] GetPartnersListQuery query) {
            var owner = await _Mediator.Send (query);
            return Ok (owner);
        }

        [HttpPost]
        public async Task<ActionResult<PartnerViewModel>> CreatePartner ([FromBody] CreatePartnerCommand command) {

            var newId = await _Mediator.Send (command);
            var newPartner = await _Mediator.Send (new GetPartnerQuery () { Id = newId });

            return StatusCode (200, newPartner);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdatePartner ([FromBody] UpdatePartnerCommand command) {
            await _Mediator.Send (command);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeletePartner (uint id) {
            await _Mediator.Send (new DeletePartnerCommand () { Id = id });
            return NoContent ();
        }
    }
}