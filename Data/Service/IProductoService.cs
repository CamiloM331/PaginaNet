using MueblesApp.Data.Model;
using System.Threading.Tasks;

namespace MueblesApp.Data.Service
{
    public interface IProductoService
    {
        Task<bool> ProductoInsert(Producto producto);
    }
}