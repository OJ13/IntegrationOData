using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.SM.API.Domain.Entities;
using Integration.SM.API.Domain.Services;
using Integration.SM.API.Infra.Mock;

namespace Integration.SM.API.Infra.External
{
    public class IntegrationSalesOrderService : ISalesOrderService
    {
        // CHAMADA EXTERNA SERIA AQUI - API SALES ORDER
        // private readonly HttpClient _httpClient;

        // public IntegrationSalesOrderService(HttpClient httpClient)
        // {
        //     _httpClient = httpClient;
        // }
        public IEnumerable<SalesOrder> GetSalesOrdersAsync()
        {
            return MockData.SalesOrders.AsEnumerable();
        }
        public SalesOrder CreateSalesOrderAsync(SalesOrder salesOrder)
        {
            var newSalesOrder = new SalesOrder
            {
                SalesOrderNumber = salesOrder.SalesOrderNumber,
                CreationDate = DateTime.UtcNow,
                CustomerId = salesOrder.CustomerId,
                TotalValue = salesOrder.TotalValue,
                Currency = salesOrder.Currency,
                Status = salesOrder.Status,
                Items = salesOrder.Items
            };
            MockData.SalesOrders.Add(newSalesOrder);

            return newSalesOrder;
        }
    }
}