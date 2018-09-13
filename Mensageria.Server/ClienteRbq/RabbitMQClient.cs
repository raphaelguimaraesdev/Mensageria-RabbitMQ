using Mensageria.Server.Basicos;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;

namespace Mensageria.API.Utilitarios
{
    public class BaseClienteMq : BaseRabbitMq
    {
        #region "Construtores"

        public BaseClienteMq(string exchangeName, string exchangeType, string queue, string routingKey)
        {
            this._exchangeName = exchangeName;
            this._exchangeType = exchangeType;
            this._queue = queue;
            this.RoutingKey = routingKey;

            DeclararFila();
        }

        #endregion "Construtores"

        private string _exchangeName;
        private string _exchangeType;
        private string _queue;
        protected string RoutingKey;

        #region "Metódos Públicos"

        protected int EnviarMensagem(byte[] tarefa)
        {
            _canal.BasicPublish(_exchangeName, RoutingKey, BasicProperties, tarefa);
            return 0;
        }


        #endregion "Metódos Públicos"

        #region "Metódos Privados"

        private void DeclararFila()
        {
            try
            {
                // Declarando a entendidade do Tipo "topic_Exchange".
                _canal.ExchangeDeclareNoWait(_exchangeName, _exchangeType);

                // Declarando a fila.
                _canal.QueueDeclareNoWait(_queue, Durable, Exclusive, AutoDelete, null);

                // Criando a ligações. Uma ligação é uma relação entre uma troca e uma fila. Isso pode ser simplesmente lido como:
                // a fila está interessada em mensagens dessa troca.
                _canal.QueueBindNoWait(_queue, _exchangeName, RoutingKey, null);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion "Metódos Privados"
    }
}