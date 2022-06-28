using MediatR;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.Application.Features.Galeries.Commands;
using SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery;
using SouthWestContractors.Application.Features.Galeries.Commands.DeleteGalery;
using SouthWestContractors.Application.Features.Galeries.Queries.GetCategoriesList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaleryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GaleryController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet (Name = "GetGaleries")]
        public async Task<ActionResult<List<GaleriesListVm>>> GetAllGaleries()
        {
            var dtos = await _mediator.Send(new GetGaleriesListQuery());
            return dtos;
        }

        [HttpPost(Name ="AddGalery")]
        public async Task<ActionResult<CreateGaleryCommandResponse>> Create([FromBody] CreateGaleryCommand galeryCommand)
        {
            var response = await _mediator.Send(galeryCommand);
            return Ok(response);
        }
        [HttpDelete(Name ="DeleteGalery")]
        public async Task<ActionResult> Delete([FromBody] DeleteGaleryCommand deleteGalery)
        {
            await _mediator.Send(deleteGalery);
            return NoContent();
        }


        
       
    }
}
