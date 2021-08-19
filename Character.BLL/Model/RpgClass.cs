using System.Text.Json.Serialization;

namespace Character.BLL.Model
{
     [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum RpgClass
    {
            Knight,
            Mage,
            Cleric
        
    }
}