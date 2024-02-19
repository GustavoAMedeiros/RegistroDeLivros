using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    static class ConexaoBanco
    {
        private const string Servidor = "Localhost";
        private const string DadosBanco = "dblivros";
        private const string Usuario = "root";
        private const string Senha = "";

        static public string BancoDados = $"server={Servidor}; user id={Usuario}; database={DadosBanco}; password={Senha}";

    }
}
