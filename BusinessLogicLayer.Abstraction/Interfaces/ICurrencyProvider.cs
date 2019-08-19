using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.Entities;

namespace Abstraction.Interfaces
{
    public interface ICurrencyProvider
    {
        Task<IEnumerable<CurrencyDataResponse>> GetAnswerAsync();
    }
}