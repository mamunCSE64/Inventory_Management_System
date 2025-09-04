using Inventory_Management_System.Models;
using MyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface IApplicationUserRepository 
    {
        Task AddUserRole(UserRole UserRole);
        Task AddUser(User User);
        Task<List<User>> GetAllUser();
        Task<int> CheckRoleId(int roleId);
    }
}
