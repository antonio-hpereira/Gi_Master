
using GiMaster_Core.Repository.Abstract;
using GiMaster_EntidadeBase;
using System.Data;
using System.Linq;

namespace GIMaster_Core.Repository.Concret
{

    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {
        public IQueryable<T> Consulta => throw new System.NotImplementedException();

        public void Alterar(T entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            throw new System.NotImplementedException();
        }

        public string ExecuteQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetDataTable(string sqlQuery)
        {
            throw new System.NotImplementedException();
        }

        public void Inserir(T entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}
