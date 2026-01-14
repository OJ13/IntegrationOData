# Integration.SM.API

API de integração com SAP S/4HANA para gestão de Pedidos de Vendas (Sales Orders) e Itens de Pedidos (Sales Order Items).

### OBSERVACAO
Como é mockado temos 2 usuários em tempos de execução:

user: usuário senha: senha@123 (Autorizado GET)
user: admin senha: senha@123 (Autorizado GET e POST)


## 📋 Descrição

Esta API fornece endpoints para consultar e gerenciar pedidos de vendas do SAP, com autenticação via JWT e documentação automática via Swagger.

## 🛠️ Tecnologias & Frameworks

### Backend
- **.NET 8.0** - Framework principal
- **ASP.NET Core** - Web framework
- **C# 12** - Linguagem de programação

### Autenticação & Segurança
- **JWT (JSON Web Tokens)** - Autenticação stateless
  - `System.IdentityModel.Tokens.Jwt` v8.15.0
  - `Microsoft.AspNetCore.Authentication.JwtBearer` v8.0.0

### Mapeamento & DTOs
- **AutoMapper** v12.0.1 - Mapeamento de objetos entre camadas

### Documentação & Testes
- **Swagger/OpenAPI** - Documentação interativa
  - `Microsoft.AspNetCore.OpenApi` v8.0.20
  - `Swashbuckle.AspNetCore` v6.6.2

## 🏗️ Arquitetura & Estrutura de Pastas

```
Integration.SM.API/
├── Endpoints/           # Roteamento e Mappers de endpoints
│   ├── SMIntegration.cs      # Endpoints de Sales Orders
│   └── DTOs/                 # Data Transfer Objects
│       └── LoginDTO.cs
│       └── SalesOrderDTO.cs
├── Application/         # Casos de uso e Serviços
│   └── Services/
│       └── SalesOrderService.cs
├── Domain/              # Entidades e Contratos
│   ├── Entities/
│   │   ├── SalesOrder.cs
│   │   └── SalesOrderItem.cs
│   └── Services/
│       └── ISalesOrderService.cs
├── Infra/               # Infraestrutura e Dados
│   └── Mock/            # Dados Mock em Memória
│       ├── Mock.cs
│       └── MockData.cs
└── Program.cs           # Configuração da aplicação

```

📁 1. Presentation <br>
📁 2. Application <br>
📁 3. Domain <br>
📁 4. Infraestructure <br>

## 🔌 Endpoints

### GET /sales
Retorna lista de pedidos de vendas.

**Autenticação:** Requerida (JWT - role: `user`)

**Response:**
```json
[
  {
    "salesOrderNumber": "0010005678",
    "creationDate": "2025-01-09T12:00:00Z",
    "customerId": "CUST001",
    "totalValue": 1500.00,
    "currency": "BRL",
    "status": "Open",
    "items": [
      {
        "itemNumber": 1,
        "materialCode": "MAT-001",
        "quantity": 10,
        "unitOfMeasure": "UN"
      }
    ]
  }
]
```

### POST /sales
Cria um novo pedido de vendas.

**Autenticação:** Requerida (JWT - role: `admin`)

**Request Body:**
```json
{
  "customerId": "CUST003",
  "salesOrderNumber": "0010005680",
  "creationDate": "2025-01-14T00:00:00Z",
  "totalValue": 500.00,
  "currency": "USD",
  "status": "Pending",
  "items": []
}
```

## 🚀 Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- Visual Studio Code ou Visual Studio

### Instalação

```bash
# Restaurar dependências
dotnet restore

# Compilar projeto
dotnet build

# Executar em Development
dotnet run --configuration Development
```

A API estará disponível em `https://localhost:5001` com Swagger em `/swagger/ui`

## 🔐 Autenticação

### JWT Configuration
A autenticação JWT deve ser configurada em `appsettings.json`:

```json
{
  "JwtSettings": {
    "Key": "sua-chave-secreta-aqui",
    "Issuer": "sua-issuer",
    "Audience": "sua-audience",
    "ExpirationMinutes": 60
  }
}
```

### Obter Token

POST `/auth/login` (implementar conforme necessário)

```json
{
  "username": "user",
  "password": "password"
}
```

## 📦 Estrutura de Dados

### SalesOrder
- `SalesOrderNumber` (string) - ID único do pedido
- `CreationDate` (DateTime) - Data de criação
- `CustomerId` (string) - ID do cliente
- `TotalValue` (decimal) - Valor total
- `Currency` (string) - Moeda (BRL, USD)
- `Status` (string) - Status (Open, In Delivery, Completed)
- `Items` (List<SalesOrderItem>) - Itens do pedido

### SalesOrderItem
- `ItemNumber` (int) - Número do item
- `MaterialCode` (string) - Código do material/medicamento
- `Quantity` (int) - Quantidade
- `UnitOfMeasure` (string) - Unidade (UN, CX)

## 📝 Notas

- Dados atualmente utilizam mock em memória via `MockData.cs`
- A API segue padrão Clean Architecture com separação de responsabilidades
- JWT é obrigatório para acessar endpoints protegidos





