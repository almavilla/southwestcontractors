using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Infrastructure;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Models.Mail;
using SouthWestContractors.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Guid>
    {
        //The name of the folders in features should be different from the entities
        private readonly IAsyncRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateContractorCommandHandler> _logger;

        public CreateContractorCommandHandler(IAsyncRepository<Contractor> contractorRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CreateContractorCommandHandler> logger)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContractorCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @contractor = _mapper.Map<Contractor>(request);

            @contractor = await _contractorRepository.AddAsync(@contractor);

            //Sending email notification to admin address
            var email = new Email()
            {
                To = "almaruthvc@gmail.com",
                Body = $"A new contractor was created: {request}",
                Subject = "A new contractor was created"
            };

            try
            {
                await _emailService.SendEmail(email);
                _logger.LogInformation($"Mailing about event " +
                   $"{@contractor.Name +    @contractor.LastName} was created");
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event " +
                    $"{@contractor.ContractorId} failed due to an error with " +
                    $"the mail service: {ex.Message}");
            }

            return @contractor.ContractorId;

           
        }
    }
}
