using FluentValidation;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Validation
{
    public class SupplierValidator : AbstractValidator<SupplierDto>
    {
        public SupplierValidator()
        {
            RuleFor(obj => obj.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters long.")
                .Matches(@"^[a-zA-Z\sÀ-ÿ]+$").WithMessage("Name must contain only letters, spaces, and extended characters.");

            RuleFor(obj => obj.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");


            RuleFor(obj => obj.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .Matches(@"^01[3-9]\d{8}$").WithMessage("Phone must be a valid Bangladesh number starting with 01 and followed by 9 digits");

            RuleFor(obj => obj.Address)
                .NotEmpty().WithMessage("address can't be empty")
                .MinimumLength(3).WithMessage("address should be at least 3 characters")
                .MaximumLength(30).WithMessage("address should be at most 30 characters");
        }
    }
}
