using System;

namespace SouthWestContractors.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        //Include CategoryId because this class is used for the response
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
