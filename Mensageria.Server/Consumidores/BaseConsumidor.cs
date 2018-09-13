using Mensageria.Server.Basicos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Mensageria.Server.Utilitarios
{
    public abstract class BaseConsumidor<T> : BaseRabbitMq
    {
        public void CriarConexao(string queue)
        {
            try
            {
                var consumer = new AsyncEventingBasicConsumer(_canal);
                consumer.Received += Consumer_Received;
                _canal.BasicConsume(queue, AutoAck, consumer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region "Metódos Protegidos"

        protected abstract T ExecutaTarefa(object sender, BasicDeliverEventArgs @event);

        protected T MontaObjeto(BasicDeliverEventArgs @event)
        {
            var tarefa = Encoding.UTF8.GetString(@event.Body);
            T objeto = (T)@event.Body.Deserializar(typeof(T));
            return objeto;
        }

        #endregion "Metódos Protegidos"

        #region "Metódos Privados"

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event) => ExecutaTarefa(sender, @event);

        #endregion "Metódos Privados"
    }
}