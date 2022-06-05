using MueblesApp.Data.Model;
using System.Threading.Tasks;

namespace MueblesApp.Data.Service
{
    public interface IComentarioService
    {
        Task<bool> ComentarioInsert(Comentario comentario);
    }
}