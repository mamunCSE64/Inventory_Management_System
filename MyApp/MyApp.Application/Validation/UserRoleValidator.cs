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
    public class UserRoleValidator : AbstractValidator<UserRoleDto>
    {
        public UserRoleValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .Must(name => name == "admin" || name == "user" )
                .WithMessage("Name must be either 'admin' or 'manager'");
        }
    }
}
