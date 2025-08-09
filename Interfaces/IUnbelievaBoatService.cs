using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwizzBotDisco.Interfaces
{
    public interface IUnbelievaBoatService
    {
        Task<int> GetBalanceAsync(ulong guildId, ulong userId);
        Task<bool> PatchUserBalanceAsync(ulong guildId, ulong userId, int amount, string reason = null);
    }
}
