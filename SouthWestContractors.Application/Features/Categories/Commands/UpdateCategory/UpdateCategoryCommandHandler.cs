﻿using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommnad>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository=categoryRepository;
            _mapper=mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommnad request, CancellationToken cancellationToken)
        {
            //Get the category to update
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.Id);
            //if not found return notFoundException
            if (categoryToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            //Create an isntance of the validator and send
            //the request to be validated
            var validator = new UpdateCategoryCommandValidator();
            var validationResult = validator.Validate(request);
            //if validatoinResult contain errors 
            //throw a new ValidationException
            if(validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            //map source, destination
            //map the request to the founded category
            //this means the request data is going to be
            //copied to the founded category
            //then call therepository to update sending the updated category
            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommnad), typeof(Category));
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            return Unit.Value;
        }
    }
}
