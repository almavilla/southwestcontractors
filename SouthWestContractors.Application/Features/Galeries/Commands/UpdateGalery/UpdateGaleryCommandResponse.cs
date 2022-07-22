using SouthWestContractors.Application.Responses;

namespace SouthWestContractors.Application.Features.Galeries.Commands.UpdateGalery
{
    public class UpdateGaleryCommandResponse: BaseResponse
    {
        public UpdateGaleryCommandResponse(): base()
        {
        }

        public UpdateGaleryDto Galery { get; set; }
    }
}
