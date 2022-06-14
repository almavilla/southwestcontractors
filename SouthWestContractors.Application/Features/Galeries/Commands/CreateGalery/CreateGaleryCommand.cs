using MediatR;
using SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery;
using System;

namespace SouthWestContractors.Application.Features.Galeries.Commands
{
    public class CreateGaleryCommand : IRequest<CreateGaleryCommandResponse>
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
