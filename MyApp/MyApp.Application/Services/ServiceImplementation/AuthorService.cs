using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys;
using MyApp.Infrastructure.Repositorys.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _registrationRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository RegistrationRepository, IMapper mapper)
        {
            _registrationRepository = RegistrationRepository;
            _mapper = mapper;
        }        


    }
}
