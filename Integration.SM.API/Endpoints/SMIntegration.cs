using Integration.SM.API.Endpoints.DTOs;
using Integration.SM.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Integration.SM.API.Endpoints
{
    public static class SMIntegration
    {
        const string PATH = "/sales";
        public static void MapSMIntegrationEndpoint(this WebApplication app)
        {
            app.MapGet(PATH, ([FromServices] ISalesOrderService _salesOrderService) =>
            {
                var salesOrders = _salesOrderService.GetSalesOrdersAsync();

                return Results.Ok(salesOrders);
            })
            .RequireAuthorization("user");

            app.MapPost(PATH, ([FromServices] ISalesOrderService _salesOrderService, SalesOrderDTO salesOrder) =>
            {
                var newSalesOrder = _salesOrderService.CreateSalesOrderAsync(salesOrder);

                
                return Results.Ok(newSalesOrder);

            }).RequireAuthorization("admin");
        }
    }
}