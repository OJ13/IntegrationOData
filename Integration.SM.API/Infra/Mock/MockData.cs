using System;
using System.Collections.Generic;
using Integration.SM.API.Domain.Entities;

namespace Integration.SM.API.Infra.Mock
{
    public static class MockData
    {
        public static List<SalesOrder> SalesOrders { get; } = new List<SalesOrder>
        {
            new SalesOrder
            {
                SalesOrderNumber = "0010005678",
                CreationDate = DateTime.UtcNow.AddDays(-5),
                CustomerId = "CUST001",
                TotalValue = 1500.00m,
                Currency = "BRL",
                Status = "Open",
                Items = new List<SalesOrderItem>
                {
                    new SalesOrderItem { ItemNumber = 1, MaterialCode = "MAT-001", Quantity = 10, UnitOfMeasure = "UN" },
                    new SalesOrderItem { ItemNumber = 2, MaterialCode = "MAT-002", Quantity = 5, UnitOfMeasure = "CX" }
                }
            },
            new SalesOrder
            {
                SalesOrderNumber = "0010005679",
                CreationDate = DateTime.UtcNow.AddDays(-2),
                CustomerId = "CUST002",
                TotalValue = 250.75m,
                Currency = "USD",
                Status = "Completed",
                Items = new List<SalesOrderItem>
                {
                    new SalesOrderItem { ItemNumber = 1, MaterialCode = "MAT-010", Quantity = 1, UnitOfMeasure = "UN" }
                }
            },
            new SalesOrder
            {
                SalesOrderNumber = "0010002828",
                CreationDate = DateTime.UtcNow.AddDays(-3),
                CustomerId = "CUST003",
                TotalValue = 15250.75m,
                Currency = "USD",
                Status = "Completed",
                Items = new List<SalesOrderItem>
                {
                    new SalesOrderItem { ItemNumber = 1, MaterialCode = "MAT-010", Quantity = 1, UnitOfMeasure = "UN" },
                    new SalesOrderItem { ItemNumber = 1, MaterialCode = "MAT-010", Quantity = 5, UnitOfMeasure = "UN" }
                }
            }
        };
    }
}
