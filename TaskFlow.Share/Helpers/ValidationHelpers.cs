using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskFlow.Share.Helpers
{
    public static class ValidationHelpers
    {
        public static void ValidateObject(object obj)
        {
            ValidationContext validationContext = new(obj);
            List<ValidationResult> validationResults = [];
            bool isValide = Validator.TryValidateObject(obj, validationContext, validationResults);
            if (!isValide)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
