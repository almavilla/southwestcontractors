using MediatR;
using System.Collections.Generic;

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList
{
    //This class is the request and it doesn't have any paramerter
    //I got an error because I was missing List
    public class GetContractorsListQuery : IRequest<List<ContractorsListVm>>
    {

    }
}
