using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList;
using SouthWestContractors.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateContractorCommandResponse>> Create([FromBody] CreateContractorCommand contractorCommand)
        {
            var response = await _mediator.Send(contractorCommand).ConfigureAwait(false);
            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ContractorsListVm>>> GetAll()
        {
            var result = await _mediator.Send(new GetContractorsListQuery()).ConfigureAwait(false);
            return Ok(result);
        }
        [HttpDelete(Name ="DeleteContractor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromBody] DeleteContractorCommand deleteContractorCommand)
        {
            await _mediator.Send(deleteContractorCommand).ConfigureAwait(false);
            return NoContent();

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateContractorCommand updateContractorCommand)
        {
            await _mediator.Send(updateContractorCommand).ConfigureAwait(false);
            return NoContent();
        }
        
    }
}
