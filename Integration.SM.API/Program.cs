using Integration.SM.API.Endpoints;
using Integration.SM.API.Endpoints.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOptions<AppSettings>()
    .Bind(builder.Configuration.GetSection(AppSettings.Config));

# region Dependency Injection

builder.Services.AddScoped<Integration.SM.API.Domain.Services.ISalesOrderService, Integration.SM.API.Infra.External.IntegrationSalesOrderService>();
builder.Services.AddScoped<Integration.SM.API.Application.Services.ISalesOrderService, Integration.SM.API.Application.Services.SalesOrderService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);    

#endregion

# region Swagger Configuration

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Integração - Desafio",
        Description = "Integração com sistemas externos utilizando OData e autenticação JWT.",
        Contact = new OpenApiContact { Name = "Osmar Junior", Email = "osmarfsjunior@outlook.com" },
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ïnsira o token JWT assim: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion

#region  Configuration JWT

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));
var config = configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config.Issuer,
        ValidAudience = config.Audience,        
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("user", policy => policy.RequireRole("user"));
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region  Endpoints
// Autenticacao - MOCK
app.MapAuthEndpoint(config);

// Endpoints de Integração
app.MapSMIntegrationEndpoint();

#endregion

app.Run();
