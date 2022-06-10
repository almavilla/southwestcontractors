using SouthWestContractors.Application.Responses;

namespace SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery
{
    public class CreateGaleryCommandResponse : BaseResponse
    {
        public CreateGaleryCommandResponse() : base()
        {
        }

        public  CreateGaleryDto Galery { get; set; }
    }
}
