using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery
{
    public class CreateGaleryCommandHandler : IRequestHandler<CreateGaleryCommand, CreateGaleryCommandResponse>
    {
        private readonly IAsyncRepository<Galery> _galeryRepository;
        private readonly IMapper _mapper;

        public CreateGaleryCommandHandler(IAsyncRepository<Galery> galeryRepository, IMapper mapper)
        {
            _galeryRepository = galeryRepository;
            _mapper = mapper;
        }

        public async Task<CreateGaleryCommandResponse> Handle(CreateGaleryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateGaleryCommandResponse();
            var validator = new CreateGaleryCommandValidator();
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
            {
                response.ValidationErrors = new List<string>();
                response.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var galery = new Galery()
                {
                    ContractorId = request.ContractorId,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl
                };
                //var galery2 = new Galery();
                //_mapper.Map(request,galery2,typeof(CreateGaleryCommand), typeof(Galery));

                galery = await _galeryRepository.AddAsync(galery);
                response.Galery = _mapper.Map<CreateGaleryDto>(galery);
            }
            return response;
        }
    }
}