using Infraestructura.General.Crypto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Data.DataAccess
{
    public class BaseDataAccess : IBaseDataAccess
    {

        private const string llaveCryptop = "Cryptokey";
        private const string ConexionBaseDeDatosEncriptada = "ConexionEncriptada";
        private const string ConexionBaseDeDatos = "ConexionSinEncriptar";
        private const string usarCrypto = "UsarCrypto";
        private IConfiguration _config;
        private ICryptographyService _crypto;
        public BaseDataAccess(IConfiguration config, ICryptographyService crypto)
        {
            _config = config;
            _crypto = crypto;

        }

        public SqlConnection GetConnection()
        {
            string conexionDesencriptada = "";

            string llaveCrypto = _config.GetSection("keys").GetSection(llaveCryptop).Value;
            string conexionEncriptada = _config.GetSection("ConnectionStrings").GetSection(ConexionBaseDeDatosEncriptada).Value;
            string conexionSinencriptar = _config.GetSection("ConnectionStrings").GetSection(ConexionBaseDeDatos).Value;

            if (Convert.ToBoolean(_config.GetSection("keys").GetSection(usarCrypto).Value))
            {
                conexionDesencriptada = _crypto.Desencriptar(llaveCrypto, conexionEncriptada);

            }
            else
            {

                conexionDesencriptada = conexionSinencriptar;
            }

            SqlConnection sqlConn = new SqlConnection(conexionDesencriptada);
            if (sqlConn.State != System.Data.ConnectionState.Open)
                sqlConn.Open();
            return sqlConn;

        
        }



    }
}
