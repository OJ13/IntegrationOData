public class SalesOrderItem
{
    public int ItemNumber { get; set; }
    public string MaterialCode { get; set; } // Código do Medicamento
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; } // Ex: CX (Caixa), UN (Unidade)
}