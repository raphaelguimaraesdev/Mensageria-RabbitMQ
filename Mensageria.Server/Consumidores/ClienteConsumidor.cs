using Mensageria.Server.Models;
using Mensageria.Server.Utilitarios;
using RabbitMQ.Client.Events;
using System;
using System.Threading;

namespace Mensageria.Server.Consumidores
{
    public class ClienteConsumidor : BaseConsumidor<Cliente>
    {
        protected override Cliente ExecutaTarefa(object sender, BasicDeliverEventArgs @event)
        {
            var objeto = MontaObjeto(@event);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("Executando tarefa! {0}: Data: {1}", @event.DeliveryTag, DateTime.Now));
            Thread.Sleep(5000);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Tarefa (DeliveryTag): {0} - CostumerTAG: {1} - Cliente: {2}-{3} finalizada com sucesso. Data: {4}", @event.DeliveryTag, @event.ConsumerTag, objeto.Codigo, objeto.Nome, DateTime.Now);
            return objeto;
        }
    }
}