using Inventory_Management_System.DTOs;
using MyApp.Application.DTOs;
using MyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceInterfaces
{
    public interface IApplicationUserService
    {
        Task AddUserRole(UserRoleDto UserRole);
        Task AddUser(UserDto User);
        Task<List<User>> GetAllUser();
        Task<int> CheckRoleID(int RoleId);
    }
}
