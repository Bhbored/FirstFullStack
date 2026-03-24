using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskFlow.Share.CustomeValidators
{
    public class DueDateValidator : ValidationAttribute
    {

        private const string DefaultErrorMessage = "Due date must be greater than or equal to today's date.";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date.Date < DateTime.Now)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, date));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Invalid date format.");
        }
    }
}
