using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.SM.API.Domain.Entities
{
    public class SalesOrder
    {
        // Chave primária no SAP (Ex: 0010005678)
        public string SalesOrderNumber { get; set; } 
        
        // Data da criação do pedido no S/4HANA
        public DateTime CreationDate { get; set; }
        
        // ID do Cliente (Sold-to Party)
        public string CustomerId { get; set; }
        
        // Valor total do pedido
        public decimal TotalValue { get; set; }
        
        // Moeda (BRL, USD)
        public string Currency { get; set; }
        
        // Status do processamento no SAP (Ex: Open, In Delivery, Completed)
        public string Status { get; set; }

        // Itens da Ordem (Relacionamento para simular OData $expand)
        public List<SalesOrderItem> Items { get; set; }

        public SalesOrder()
        {
            Items = new List<SalesOrderItem>();
        }
        
    }
}