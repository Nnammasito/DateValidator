#pragma warning disable CS8618
using System;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage="Field should be 2 characters or greater")]
        [Display(Name="Your Name:")]
        public string Name {get;set;}
        [Required]
        [Display(Name="Your Location:")]
        public string Location {get;set;}
        [Required]
        [Display(Name="Favorite Language:")]
        public string Language {get;set;}
        [MinLength(20, ErrorMessage="Field should be 20 characters or greater")]
        [Display(Name="Leave a comment? (optional)")]
        public string? Comment {get;set;}

        [Required(ErrorMessage = "Register date time is required!")]
        [FutureDateAttribute]
        public DateTime? RegisterDateTime { get; set; }

        public Survey(){}

        public Survey(string name, string location, string language, string comment)
        {
            Name = name;
            Location = location;
            Language = language;
            Comment = comment;
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date > DateTime.Now)
                {
                    return ValidationResult.Success!; // La fecha es válida.
                }
            }

            return new ValidationResult("La fecha debe ser posterior a la fecha actual.");
        }
    }
}