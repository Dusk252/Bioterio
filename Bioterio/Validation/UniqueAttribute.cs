using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bioterio.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    sealed public class UniqueAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Já existe uma entidade {0} com {1} {2}.";

        private readonly bd_lesContext _context;

        public UniqueAttribute(string value, bd_lesContext context) : base(DefaultErrorMessage)
        {
            _context = context;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }

        protected override ValidationResult IsValid(object value,
                              ValidationContext validationContext)
        {
            if (value != null)
            {/*
                var otherProperty = validationContext.ObjectInstance.GetType()
                                   .GetProperty(OtherProperty);

                var otherPropertyValue = otherProperty
                              .GetValue(validationContext.ObjectInstance, null);

                if (value.Equals(otherPropertyValue))
                {
                    return new ValidationResult(
                      FormatErrorMessage(validationContext.DisplayName));
                }*/
            }

            return ValidationResult.Success;
        }
    }

}
