using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using MyApp.Application.Services.ServiceInterfaces;
using MyApp.Core.Models;
using MyApp.Infrastructure.Repositorys.IRepository;
using MyApp.Infrastructure.Repositorys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceImplementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        public readonly IApplicationUserRepository _applicationUserRepository;
        public readonly IMapper _mapper;
        public ApplicationUserService(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }
        // add AddRole
        public async Task AddUserRole(UserRoleDto UserRole1)
        {
            var UserRole = _mapper.Map<UserRole>(UserRole1);
            await _applicationUserRepository.AddUserRole(UserRole);

        }
        // add AddUser
        public async Task AddUser(UserDto User)
        {
            var User1 = _mapper.Map<User>(User);
            await _applicationUserRepository.AddUser(User1);
        }
        // get all customer
        public async Task<List<User>> GetAllUser()
        {
            return await _applicationUserRepository.GetAllUser();
        }
        // check Role Id
        public async Task<int> CheckRoleID(int RoleId)
        {             
            return await _applicationUserRepository.CheckRoleId(RoleId);
        }
    }
}
