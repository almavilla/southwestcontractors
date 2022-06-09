using MediatR;
using System;

namespace SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommnad : IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
