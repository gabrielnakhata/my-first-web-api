using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_first_web_api.Controllers.Util;
using my_first_web_api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace my_first_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
           

            return new string[] { "value1", "value2" };

        }

        // GET api/values/S
        [HttpGet("{id}")]

        public string Get(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"select * from cliente where id = {id}";
                DataTable dados = objDAL.RetornarDataTable(sql);

            return dados.Rows[0]["Nome"].ToString();
        }

        // POST api/values
        [HttpPost]
        [Route("registrarcliente")]

        public ReturnAllServices RegistrarCliente([FromBody]ClienteModel dados)
        {
            ReturnAllServices retorno = new();
            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return retorno;
        }

        // PUT api/values/S
        [HttpPut("{id}")]

        public void Put(int id, [FromBody]string value)
        { 
        }
    }
}
