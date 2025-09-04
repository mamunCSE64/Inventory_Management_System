using FluentValidation;
using Inventory_Management_System.DTOs;

namespace Inventory_Management_System.Validation
{
    public class warHouseValidate : AbstractValidator<warhouse>
    {
        public warHouseValidate()
        {
            RuleFor(obj => obj.name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters long.")
                .Matches(@"^[a-zA-Z\sÀ-ÿ]+$").WithMessage("Name must contain only letters, spaces, and extended characters.");

            RuleFor(obj => obj.location)
                .NotEmpty().WithMessage("Location is required.")
                .Length(3, 30).WithMessage("Location must be between 3 and 30 characters long.");
        }
    }
}
