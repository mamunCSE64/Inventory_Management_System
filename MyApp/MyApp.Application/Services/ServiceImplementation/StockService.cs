using AutoMapper;
using Inventory_Management_System.DTOs;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using MyApp.Application.Services.ServiceInterfaces;
using MyApp.Infrastructure.Repositorys.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceImplementation
{
    public class StockService : IStockService
    {
        public readonly IStockRepository _stockService;
        public readonly IMapper _mapper;
        public StockService(IStockRepository stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        public async Task<int> GetStockByProductId(int Id)
        {
            return await _stockService.GetStockByProductId1(Id);
        }
        // get wareHouseWise all products
        public async Task<List<ProductStockDto>> GetWarehouseWiseProducts(int WarhouseId)
        {
            var WarHouse = await _stockService.GetWarehouseWiseProducts(WarhouseId);
            var ProductQuanity = _mapper.Map<List<ProductStockDto>>(WarHouse);

            return ProductQuanity;
        }
    }
}
