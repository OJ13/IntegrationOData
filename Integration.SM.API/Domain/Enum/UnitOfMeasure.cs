using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Integration.SM.API.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum UnitOfMeasure
    {
        [Description("Unit")]
        UN,    // Unidade (Padrão SAP: PC ou UN)

        [Description("Box")]
        BX,    // Caixa (Padrão SAP: BX)

        [Description("Carton")]
        CT,    // Cartucho/Caixa de Papelão

        [Description("Vial")]
        VI,    // Frasco/Ampola (Comum em injetáveis)

        [Description("Milligram")]
        MG,    // Miligrama (Para pesagem de insumos)

        [Description("Milliliter")]
        ML,    // Mililitro (Para soluções líquidas)

        [Description("Pallet")]
        PAL    // Palete (Para logística de distribuição no módulo SD)
    }
}