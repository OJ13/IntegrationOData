using Integration.SM.API.Domain.Entities;

namespace Integration.SM.API.Domain.Services
{
    public interface ISalesOrderService
    {
        IEnumerable<SalesOrder> GetSalesOrdersAsync();

        SalesOrder CreateSalesOrderAsync(SalesOrder salesOrder);
    }
}