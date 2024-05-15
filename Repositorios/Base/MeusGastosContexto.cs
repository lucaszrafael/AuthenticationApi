using Repositorios.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Repositorios.Base
{
    public class MeusGastosContexto : ContextoBancoBase, IMeusGastosContexto
    {
        public MeusGastosContexto(IConfiguration configuracoes) : base()
        {
            Conexao = new SqlConnection(configuracoes.GetSection("ConnectionStrings:AZURE_SQL_CONNECTIONSTRING").Value);
        }

    }
}
