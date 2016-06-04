using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //cast the object instance to type customer
            var customer = (Customer) validationContext.ObjectInstance;

            
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                //use this static field to return a successfull valid state
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                //for an error you instanciate a new valdiationResult
            return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on membership");
        }
    }
}