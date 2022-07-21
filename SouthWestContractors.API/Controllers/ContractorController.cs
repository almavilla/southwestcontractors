using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.API.Models;
using SouthWestContractors.Application.Features.ContractorCategories.Commands.CreateContractorCategories;
using SouthWestContractors.Application.Features.ContractorCategories.Commands.DeleteContractorCategories;
using SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContractorController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            
        }
        [Authorize]
        [HttpPost ("Create", Name="CreateContractor")]
        public async Task<ActionResult<CreateContractorCommandResponse>> Create([FromBody] CreateContractorCommand contractorCommand)
        {
            var response = await _mediator.Send(contractorCommand).ConfigureAwait(false);
            return Ok(response);
        }
       // [Authorize]
        [HttpGet ("GetAll", Name = "GetAllContractors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ContractorsListVm>>> GetAll()
        {
            var result = await _mediator.Send(new GetContractorsListQuery()).ConfigureAwait(false);
            return Ok(result);
        }
        [HttpGet("GetDetail", Name = "GetContractorDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ContractorDetailVM>> GetContractorDetail(Guid contractorId)
        {
            var result = await _mediator.Send(new GetContractorDetailQuery() { ContractorId = contractorId }).ConfigureAwait(false);
            return Ok(result);
        }
        [HttpDelete("Delete", Name ="DeleteContractor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromBody] DeleteContractorCommand deleteContractorCommand)
        {
            await _mediator.Send(deleteContractorCommand).ConfigureAwait(false);
            return NoContent();

        }

        [HttpPut("Update", Name ="UpdateContractor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateContractorCommand updateContractorCommand)
        {
            var response = await _mediator.Send(updateContractorCommand).ConfigureAwait(false);        
            return Ok(response);            
        }
        
    }
}
