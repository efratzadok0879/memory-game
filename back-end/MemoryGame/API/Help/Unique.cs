using API.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API.Help
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Unique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                string userName = value.ToString();
                bool isUnique = DB.Users.FirstOrDefault(user => user.UserName.Equals(userName)) == null;
                if (isUnique == false)
                    validationResult = new ValidationResult(ErrorMessageString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validationResult;
        }
    }
}