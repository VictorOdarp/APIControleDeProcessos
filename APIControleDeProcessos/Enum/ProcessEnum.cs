using System.Text.Json.Serialization;

namespace APIControleDeProcessos.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProcessEnum
    {
        Corte,
        Usinagem,
        Solda,
        Pintura,
        Inspeção,
        Embalagem,
        Entregue
    }
}
