/*
 * @CreateTime: May 6, 2019 11:56 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 2, 2019 11:52 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicRent.Application.Models;
using BionicRent.Application.SystemLookups.Commands.CreateSystemLookup;
using BionicRent.Application.SystemLookups.Commands.DeleteSystemLookup;
using BionicRent.Application.SystemLookups.Commands.UpdateSystemLookup;
using BionicRent.Application.SystemLookups.Models;
using BionicRent.Application.SystemLookups.Queries.GetSystemLookup;
using BionicRent.Application.SystemLookups.Queries.GetSystemLookupList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicRent.Api.Controllers.SystemLookups {

    /// <summary>
    /// handles all crud related request linked with system lookup 
    /// </summary>
    [Route ("api/system-lookups")]
    public class SystemLookupController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// initializes system lookup class every time its requested
        /// </summary>
        /// <param name="mediator"></param>
        public SystemLookupController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns single instance of system lookup based on the id provided in the url
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<SystemLookupViewModel>> FindSystemLookupById (int id) {

            var lookup = await _Mediator.Send (new GetSystemLookupQuery () { Id = id });
            return StatusCode (200, lookup);
        }

        /// <summary>
        /// return list of lookup belonging to the same type specified in the url
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemLookupViewModel>>> GetSystemLookupList ([FromQuery] GetSystemLookupByTypeQuery query) {
            var lookup = await _Mediator.Send (query);
            return Ok (lookup);
        }

        /// <summary>
        /// return all the list of system lookups available in the system
        /// </summary>
        /// <returns></returns>
        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<SystemLookupViewModel>>> GetSystemLookUpList ([FromBody] GetSystemLookupListQuery query) {
            var result = await _Mediator.Send (query);
            return Ok (result);
        }

        /// <summary>
        /// handles the creating of systemlook up and accepts array of system lookup defininitions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> CreateSystemLookup ([FromBody] CreateSystemLookupCommand model) {
            var result = await _Mediator.Send (model);

            return StatusCode (201, result);
        }

        /// <summary>
        /// updates  instance of arrays of system lookup 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<ActionResult> UpdateSystemLookup ([FromBody] UpdateSystemLookupCommand model) {
            var result = await _Mediator.Send (model);
            return NoContent ();
        }

        /// <summary>
        /// removes single instance of system lookup object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteSystemLookup (uint id) {
            var result = await _Mediator.Send (new DeleteSystemLookupCommand () { Id = id });
            return NoContent ();
        }

        /// <summary>
        /// returns all available lookup categories used in the system
        /// </summary>
        /// <returns></returns>

        [HttpGet ("categories")]
        public async Task<ActionResult<IEnumerable<SystemLookupCategoryIndexView>>> GetSystemLookupCategories ([FromQuery] GetSystemLookupCategoriesListQuery query) {
            var lookupCategories = await _Mediator.Send (new GetSystemLookupCategoriesListQuery ());
            return Ok (lookupCategories);
        }

    }
}