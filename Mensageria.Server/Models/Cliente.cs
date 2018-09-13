namespace Mensageria.Server.Models
{
    public class Cliente
    {
        public Cliente(string codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }

        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}