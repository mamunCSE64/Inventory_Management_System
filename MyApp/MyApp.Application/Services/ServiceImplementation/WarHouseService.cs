using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class WarHouseService : IWarhouseService
    {
        private readonly IWarHouseRepository _warHouseRepository;
        private readonly IMapper _mapper;
        public WarHouseService(IWarHouseRepository WarHouseRepository, IMapper mapper)
        {
            _warHouseRepository = WarHouseRepository;
            _mapper = mapper;
        }
       
        // add warhouse
        public async Task AddWarehouse(WarhouseDto Warhouse)
        {
            var WarHouse = _mapper.Map<WarHouse>(Warhouse);
            await _warHouseRepository.AddWarehouse(WarHouse);

        }
        // delete warehouse
        public async Task<int> Deletewarhouse(int Id)
        {
            return await _warHouseRepository.DeleteWarehouse(Id);
        }
        // get all warhouse
        public async Task<List<WarHouse>> GetAllWarehouses()
        {
            return await _warHouseRepository.GetAllWarehouses(); 
        }
        // warhouse_stock
        public async Task<List<WareHouseStock>> GetAllWarehouseStocks()
        {
            return await _warHouseRepository.GetAllWarehouseStocks();
        }

    }
}
