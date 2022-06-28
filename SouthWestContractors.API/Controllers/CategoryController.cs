using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SouthWestContractors.Application.Features.Categories.Commands.CreateCategory;
using SouthWestContractors.Application.Features.Categories.Commands.DeleteCategory;
using SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory;
using SouthWestContractors.Application.Features.Categories.Queries.GetCategoriesList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [Authorize]
        [HttpGet("all", Name ="GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }
        [Authorize]
        [HttpPost("create", Name ="AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand categoryCommand)
        {
            var response = await _mediator.Send(categoryCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommnad updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteCategory")]
        public async Task<ActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
        }
    }
}
