using MediatR;
using System;

namespace SouthWestContractors.Application.Features.Galeries.Commands.DeleteGalery
{
    public class DeleteGaleryCommand : IRequest
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
    }
}
