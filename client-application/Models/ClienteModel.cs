using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client_application.Util;
using Newtonsoft.Json;

namespace client_application.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> retorno = new();
            string Json = WebAPI.RequestGET("Cliente", "listagem");
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(Json);
            return retorno;
        }
    }
}
