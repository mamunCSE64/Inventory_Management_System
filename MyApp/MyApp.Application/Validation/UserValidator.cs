using FluentValidation;
using Inventory_Management_System.DTOs;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator() 
        {
            RuleFor(User => User.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .MinimumLength(3).WithMessage("Name should be at least 3 characters")
                .MaximumLength(20).WithMessage("Name should be at most 20 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters and spaces");

            RuleFor(User => User.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(User => User.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .Matches(@"^01[3-9]\d{8}$").WithMessage("Phone must be a valid Bangladesh number starting with 01 and followed by 9 digits");
        }  
    }
}
