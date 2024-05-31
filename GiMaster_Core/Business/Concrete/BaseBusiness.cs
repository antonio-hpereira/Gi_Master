using GiMaster_Core.Business.Abstract;
using GiMaster_EntidadeBase;
using System.Data;
using System.Linq;

namespace GIMaster_Core.Business.Concret
{
    public class BaseBusiness<T> : IBaseBusiness<T> where T : EntidadeBase
    {

        public void Inserir(T entidade)
        {
            throw new System.NotImplementedException();
        }

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

        public long GetNextNumber(string modulo, string query)
        {
            throw new System.NotImplementedException();
        }

       

        public void Terminar(T entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}
