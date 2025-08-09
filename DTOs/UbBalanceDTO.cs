using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwizzBotDisco.DTOs
{
    public class UbBalanceDTO
    {
        [JsonPropertyName("user_id")]
        public string UserId  { get; set; }
        [JsonPropertyName("cash")]
        public int Cash       { get; set; }
        [JsonPropertyName("bank")]
        public int Bank       { get; set; }
        [JsonPropertyName("total")]
        public int TotalMoney { get; set; }
    }
}
