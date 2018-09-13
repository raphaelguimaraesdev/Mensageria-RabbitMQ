using Mensageria.API.Utilitarios;
using Mensageria.Server.Models;
using Mensageria.Server.Utilitarios;
using System.Threading.Tasks;

namespace Mensageria.Server.ClienteRbq
{
    public class ClienteMqClient : BaseClienteMq
    {
        public ClienteMqClient(string exchangeName, string exchangeType, string queue, string routingKey) : base(exchangeName, exchangeType, queue, routingKey)
        {
        }

        public async Task<int> CadastrarClienteAsync(Cliente cliente)
        {
            var objetoSerializado = cliente.Serializar();
            return EnviarMensagem(objetoSerializado);
        }
    }
}