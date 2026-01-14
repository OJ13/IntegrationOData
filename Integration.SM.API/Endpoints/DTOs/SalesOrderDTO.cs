using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.SM.API.Endpoints.DTOs
{
    public record SalesOrderDTO(
        string SalesOrderNumber,
        string CustomerId,
        decimal TotalValue,
        string Currency,
        string Status,
        List<SalesOrderItemDTO> Items
    );

    public record SalesOrderItemDTO(
        int ItemNumber,
        string MaterialCode,
        decimal Quantity,
        string UnitOfMeasure
    );
}