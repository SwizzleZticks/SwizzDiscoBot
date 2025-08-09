using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwizzBotDisco.DTOs
{
    public class UbPatchDTO
    {
        [JsonPropertyName("cash")]
        public int Cash { get; set; }
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
