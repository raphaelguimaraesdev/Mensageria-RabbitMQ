using RabbitMQ.Client;

namespace Mensageria.Server.Basicos
{
    public static class AjudanteConexaoRabbitMQ
    {
        #region #Constantes"

        private const string _host = "localhost";
        private const string _senha = "guest";
        private const string _usuario = "guest";

        #endregion #Constantes"

        public static ConnectionFactory CrieObjetoConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = _host,
                UserName = _usuario,
                Password = _senha,
                DispatchConsumersAsync = true
            };
        }
    }
}