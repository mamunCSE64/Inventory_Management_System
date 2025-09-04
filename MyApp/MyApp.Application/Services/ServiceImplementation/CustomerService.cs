using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // add Addcustomer
        public async Task AddCustomer(CustomerDto Customer)
        {
            var Customers = _mapper.Map<Customer>(Customer);
            await _customerRepository.AddCustomer(Customers);

        }
         
        // get all customer
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

    }
}
