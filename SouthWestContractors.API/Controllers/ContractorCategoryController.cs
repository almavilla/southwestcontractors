using MediatR;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.Application.Features.ContractorCategories.Commands.CreateContractorCategories;
using SouthWestContractors.Application.Features.ContractorCategories.Commands.DeleteContractorCategories;
using SouthWestContractors.Application.Features.ContractorCategories.Queries.GetContractorCategories;
using SouthWestContractors.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorCategoryController : ControllerBase
    {
        private readonly IMediator  _mediator;

        public ContractorCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create", Name = "AddContractorCategories")]
        public async Task<ActionResult<BaseResponse>> Add([FromBody] CreateContractorCategoriesCommand contractorCategories)
        {
            var response = await _mediator.Send(contractorCategories);
            return Ok(response);

        }

        [HttpPost("GetCategories", Name = "GetContractorCategories")]
        public async Task<ActionResult<List<Guid>>> Get([FromBody] GetContractorCategoriesListQuery contractorId)
        {
            var contractorCategories = await _mediator.Send(contractorId);
            return Ok(contractorCategories);
        }

        [HttpDelete("Delete", Name = "DeleteContractorCategories")]
        public async Task<ActionResult<BaseResponse>> Delete([FromBody] DeleteContractorCategoriesCommand contractorId)
        {
            var response = await _mediator.Send(contractorId);
            return Ok(response);
        }
    }
}
