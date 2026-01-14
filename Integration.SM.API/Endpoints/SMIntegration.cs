using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.SM.API.Endpoints
{
    public static class SMIntegration
    {
        public static void MapSMIntegrationEndpoint(this WebApplication app)
        {
            app.MapGet("/teste1", () => "Integration.SM.API is running...").RequireAuthorization("user");

            app.MapPost("/teste2", () => "Integration.SM.API 2 is running...").RequireAuthorization("admin");
        }
    }
}