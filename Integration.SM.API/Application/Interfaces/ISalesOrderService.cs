using Integration.SM.API.Endpoints.DTOs;

namespace Integration.SM.API.Application.Services
{
    public interface ISalesOrderService
    {
         IEnumerable<SalesOrderDTO> GetSalesOrdersAsync();

         SalesOrderDTO CreateSalesOrderAsync(SalesOrderDTO salesOrder);
    }
}