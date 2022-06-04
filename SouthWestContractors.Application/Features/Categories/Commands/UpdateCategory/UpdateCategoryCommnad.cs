using MediatR;
using System;

namespace SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommnad : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
