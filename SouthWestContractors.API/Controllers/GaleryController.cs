using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<List<GaleriesListVm>>> GetAllGaleries()
        {
            var dtos = await _mediator.Send(new GetGaleriesListQuery());
            return dtos;
        }
        
       
    }
}
