using FluentValidation;
using Inventory_Management_System.DTOs;
using Microsoft.AspNetCore.Components.Forms;

namespace Inventory_Management_System.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(obj => obj.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .MinimumLength(3).WithMessage("Name should be at least 3 characters")
                .MaximumLength(20).WithMessage("Name should be at most 20 characters")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters and spaces");

            RuleFor(obj => obj.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(obj => obj.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .Matches(@"^01[3-9]\d{8}$").WithMessage("Phone must be a valid Bangladesh number starting with 01 and followed by 9 digits");

            RuleFor(obj => obj.Address)
                .NotEmpty().WithMessage("Address can't be empty")
                .MinimumLength(3).WithMessage("Address should be at least 3 characters")
                .MaximumLength(30).WithMessage("Address should be at most 30 characters");
        }
    }
}
