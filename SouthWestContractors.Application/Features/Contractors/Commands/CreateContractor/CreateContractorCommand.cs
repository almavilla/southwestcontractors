using MediatR;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
