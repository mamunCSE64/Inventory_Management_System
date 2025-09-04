using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;
        private readonly IMapper _mapper;
        public SupplyService(ISupplyRepository SupplyRepository, IMapper mapper)
        {
            _supplyRepository = SupplyRepository;
            _mapper = mapper;
        }
       
        // get all supplier
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _supplyRepository.GetAllSuppliers();
        }
        // add supplier
        public async Task AddSupplier(SupplierDto Suplier)
        {
            var Supplier = _mapper.Map<Supplier>(Suplier);
            await _supplyRepository.AddSupplier(Supplier);
        }

    }
}
