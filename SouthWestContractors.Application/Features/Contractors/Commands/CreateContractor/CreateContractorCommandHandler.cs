using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, CreateContractorCommandResponse>
    {
        //The name of the folders in features should be different from the entities
        private readonly IAsyncRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public CreateContractorCommandHandler(IAsyncRepository<Contractor> contractorRepository,
            IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<CreateContractorCommandResponse> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateContractorCommandResponse();
            
            var validator = new CreateContractorCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count<0)
            {
                var errorList = new List<string>();
                response.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    errorList.Add(error.ErrorMessage);
                }

            }
            if (response.Success)
            {
                response.Success = true;
                var contractor = new Contractor()
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    LastName = request.LastName,
                    Address = request.Address

                };
                //_mapper.Map(request, contractor, typeof(CreateContractorCommand), typeof(Contractor));
                contractor= await _contractorRepository.AddAsync(contractor);
                response.Contractor= _mapper.Map<CreateContractorDto>(contractor);
            }
            return response;
        }
    }
}
