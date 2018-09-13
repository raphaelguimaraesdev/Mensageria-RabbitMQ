using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensageria.API.Utilitarios;
using Mensageria.Server.ClienteRbq;
using Mensageria.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mensageria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet()]
        public async Task<String> Obtenha()
        {
            Console.WriteLine("Executando a API Obtenha()");
            StringBuilder texto = new StringBuilder();
            ClienteMqClient rb = new ClienteMqClient("exchange_Teste", "topic", "Cliente", "Obtenha.Usuario");
            Cliente cliente = new Cliente("100", "Raphael Teste");
            var tarefa = rb.CadastrarClienteAsync(cliente);
            Console.WriteLine("Data: {0}, DeliveryTag: {1}", DateTime.Now.ToString(), tarefa.Result.ToString());
            rb.Fechar();

            return texto.ToString();
        }

    }
}
