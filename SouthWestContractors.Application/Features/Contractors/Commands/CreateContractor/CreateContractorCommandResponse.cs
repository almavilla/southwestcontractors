using SouthWestContractors.Application.Responses;

namespace SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandResponse : BaseResponse
    {
        //reforzar
        public CreateContractorCommandResponse() : base()
        {
        }
        //Contractor only
        public CreateContractorDto Contractor { get; set; }
    }
}
