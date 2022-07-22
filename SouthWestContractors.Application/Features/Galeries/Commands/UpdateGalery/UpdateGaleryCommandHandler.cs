using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Galeries.Commands.UpdateGalery
{
    public class UpdateGaleryCommandHandler : IRequestHandler<UpdateGaleryCommand, UpdateGaleryCommandResponse>
    {
        private readonly IAsyncRepository<Galery> _galeryRepository;
        private readonly IMapper _mapper;

        public UpdateGaleryCommandHandler(IAsyncRepository<Galery> galeryRepository, IMapper mapper)
        {
            _galeryRepository = galeryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGaleryCommandResponse> Handle(UpdateGaleryCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateGaleryCommandResponse();
            var validator = new UpdateGaleryCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
            {
                response.ValidationErrors = new List<string>();
                response.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ToString());
                };
            }
            if (response.Success == true)
            {
                var galery = new Galery() 
                {
                    GaleryId=request.GaleryId,
                    ContractorId=request.ContractorId,
                    ImageUrl=request.ImageUrl,
                    Description=request.Description,
                };

                galery = await _galeryRepository.UpdateAsync(galery);

                try
                {
                    response.Galery = _mapper.Map<UpdateGaleryDto>(galery);
                }
                catch (Exception ex)
                {
                    throw ex;
                }             
                
            }
            return response;
        }
    }
}
