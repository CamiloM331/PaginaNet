using MueblesApp.Data.Model;
using System.Threading.Tasks;

namespace MueblesApp.Data.Service
{
    public interface IClienteService
    {
        Task<bool> ClienteInsert(Cliente cliente);
    }
}