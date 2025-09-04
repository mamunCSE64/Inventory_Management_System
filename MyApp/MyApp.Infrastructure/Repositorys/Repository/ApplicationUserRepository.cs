using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Models;
using MyApp.Infrastructure.Repositorys.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        private readonly MyAppDbContext _context;
        public ApplicationUserRepository(MyAppDbContext context)
        {
            _context = context;
        }
        // add UserRole
        public async Task AddUserRole(UserRole UserRole)
        {
            var Role = await _context.UserRoles.FirstOrDefaultAsync
                (r => r.Name == UserRole.Name);
            if(Role is null)
            {
                await _context.UserRoles.AddAsync(UserRole);
                await _context.SaveChangesAsync();
            }
        }
        // add User
        public async Task AddUser(User User)
        {
            var Flag = await _context.Users
                .FirstOrDefaultAsync(U => U.Email == User.Email && U.Phone == User.Phone);
            if(Flag is null)
            {
                await _context.Users.AddAsync(User);
                await _context.SaveChangesAsync();
            }

        }
        // get all User
        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }
        // check Role Id
        public async Task<int> CheckRoleId(int RoleId)
        {
            var Flag = await _context.UserRoles.FindAsync(RoleId);
            if (Flag == null) return 0;
            return 1;
        }

    }
}
