using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service_Layer.Service_Interface
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDto Customer);
        Task<List<Customer>> GetAllCustomers();
    }
}
