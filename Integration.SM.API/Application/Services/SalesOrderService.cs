using AutoMapper;
using Integration.SM.API.Endpoints.DTOs;

namespace Integration.SM.API.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly Integration.SM.API.Domain.Services.ISalesOrderService _salesOrderService;
        private readonly IMapper _mapper;

        public SalesOrderService(Integration.SM.API.Domain.Services.ISalesOrderService salesOrderService, IMapper mapper)
        {
            _salesOrderService = salesOrderService;
            _mapper = mapper;
        }

        public IEnumerable<SalesOrderDTO> GetSalesOrdersAsync()
        {
          try {
            var salesOrders = _salesOrderService.GetSalesOrdersAsync();
            var salesOrderDtos = _mapper.Map<IEnumerable<SalesOrderDTO>>(salesOrders);

            return salesOrderDtos;

          } catch (Exception ex) {
            //IDEL é LOG
            Console.WriteLine($"Error in GetSalesOrdersAsync: {ex.Message}");  
            throw; 
          }
        }

        public SalesOrderDTO CreateSalesOrderAsync(SalesOrderDTO salesOrder)
        {
            try {
                var newSalesOrder = _mapper.Map<Integration.SM.API.Domain.Entities.SalesOrder>(salesOrder);

                var salesDto = _salesOrderService.CreateSalesOrderAsync(newSalesOrder);

                return _mapper.Map<SalesOrderDTO>(salesDto);
            } catch (Exception ex) {
                //IDEL é LOG
                Console.WriteLine($"Error in CreateSalesOrderAsync: {ex.Message}");  
                throw; 
            }
        }
    }
}