using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface ISupplyRepository
    {
        
        Task AddSupplier(Supplier ob1);
        Task<List<Supplier>> GetAllSuppliers();
    }
}
