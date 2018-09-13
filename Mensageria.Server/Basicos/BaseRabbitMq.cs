using RabbitMQ.Client;

namespace Mensageria.Server.Basicos
{
    public class BaseRabbitMq
    {
        protected static IModel _canal;

        protected static IConnection _connection;

        protected static ConnectionFactory _factory;

        protected bool AutoAck;
        protected bool AutoDelete;

        protected IBasicProperties BasicProperties;
        protected bool Durable;

        protected bool Exclusive;
        #region "Metódos Públicos"

        public BaseRabbitMq()
        {
            CriaConexao();
        }

        public void Fechar()
        {
            _connection.Close();
        }

        public void MontaParametrosRabbit(bool autoDelete, bool durable, bool exclusive, IBasicProperties basicProperties)
        {
            this.AutoDelete = autoDelete;
            this.Durable = durable;
            this.Exclusive = exclusive;
            this.BasicProperties = basicProperties;
        }

        public void MontaParametrosRabbit(bool autoAck)
        {
            this.AutoAck = autoAck;
        }
        #endregion "Metódos Públicos"

        private void CriaConexao()
        {
            try
            {
                // Incluir informações para acessar RabbitMQ
                _factory = AjudanteConexaoRabbitMQ.CrieObjetoConnectionFactory();

                // Criando Conexão com o Rabbitmq.
                _connection = _factory.CreateConnection();

                // Criando o modelo.
                _canal = _connection.CreateModel();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}