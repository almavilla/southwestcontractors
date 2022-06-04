using System;

namespace SouthWestContractors.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        //Include the id because this class is used for the response
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
