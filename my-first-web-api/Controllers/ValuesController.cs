using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_first_web_api.Controllers.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_first_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            DAL objDAL = new DAL();

            string sql = "insert into cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                         "values('Gabriel', '2022/02/28', '09609089766', '1990/09/14', 'F', '998784512', 'gabrielnakata@gmail.com', '31635110', 'Rua joaquim de Figueiredo', '400', 'Barreiro', 'loja', 'Belo Horizonte', 'Minas Gerais')";

            objDAL.ExecutarComandoSQL(sql);

            return new string[] { "value1", "value2" };

        }

        [HttpGet("{id}")]

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]

        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]

        public void Put(int id, [FromBody]string value)
        { 
        }
    }
}
