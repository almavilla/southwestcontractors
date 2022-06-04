using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        //list of strings for validationErrors
        public List<string> ValidationErrors { get; set; }
        //using FluentValidation.Results
        public ValidationException(ValidationResult validationResult)
            : base($"Some validation errors ocurred")
        {
            //Add the erroes to the list
            ValidationErrors = new List<string>();
            foreach(var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }

        }

        //ValidationException


    }
}
