using MediatR;
using System;

namespace SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
