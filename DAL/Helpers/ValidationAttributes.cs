using DAL.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Helpers
{

    public class EndDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TodoObjectViewModel task = (TodoObjectViewModel)validationContext.ObjectInstance;
            if (task.StartTime > task.EndTime)
            {
                return new ValidationResult("End Time must be after start time");
            }
            else return ValidationResult.Success;
        }
    }
    public class StartDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TodoObjectViewModel task = (TodoObjectViewModel)validationContext.ObjectInstance;
            if (task.StartTime < DateTime.Now)
            {
                return new ValidationResult("Start Time can't be in the past");
            }
            else return ValidationResult.Success;

        }
    }

}
