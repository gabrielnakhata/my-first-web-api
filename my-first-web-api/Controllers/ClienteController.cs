using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_first_web_api.Controllers.Util;
using my_first_web_api.Models;
using my_first_web_api.Util;
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
        Autenticacao AutenticacaoServico;
        public ClienteController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }

        [HttpGet]
        [Route("listagem")]
        public List<ClienteModel> Listagem()
        {
            AutenticacaoServico.Autenticar();
            return new ClienteModel().Listagem();
        }

        [HttpGet]
        [Route("cliente/{id}")]
        public ClienteModel RetornarCliente(int id)
        {
            AutenticacaoServico.Autenticar();
            return new ClienteModel().RetornarCliente(id);
        }

        [HttpPost]
        [Route("registrarcliente")]

        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new();
            try
            {
                AutenticacaoServico.Autenticar();
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente registrado com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new();
            try
            {
                dados.Id = id;
                AutenticacaoServico.Autenticar();
                dados.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar um cliente: " + ex.Message;
            }

            return retorno;

        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente excluido com sucesso!";
                AutenticacaoServico.Autenticar();
                new ClienteModel().Excluir(id);
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
