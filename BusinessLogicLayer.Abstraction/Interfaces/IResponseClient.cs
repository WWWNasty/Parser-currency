using System.Threading.Tasks;
using DataAccessLayer.Models.Entities;

namespace Abstraction.Interfaces
{
    public interface IResponseClient
    {
        Task<string> SendMessage(Updates updates);
    }
}