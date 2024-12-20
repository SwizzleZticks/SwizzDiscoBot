using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwizzBotDisco.Config
{
    public class JSONReader
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public static async Task<string> GetTokenAsync()
        {
            JSONReader? data;

            using (StreamReader sr = new StreamReader("../../../config/config.json"))
            {
                string json = await sr.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<JSONReader>(json);
            }

            return data.Token;
        }
    }
}
