using Mensageria.Server.Consumidores;
using Mensageria.Server.Utilitarios;

namespace Mensageria.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClienteConsumidor rabbit = new ClienteConsumidor();
            rabbit.CriarConexao("Cliente");
        }
    }
}