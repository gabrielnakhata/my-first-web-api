using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_first_web_api.Util
{
    public class Autenticacao
    {
        public static string TOKEN = "123GNK446";
        public static string FALHA_AUTENTICACAO = "Falha na autenticação... O token informado é inválido!";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (String.Equals(TOKEN, TokenRecebido) == false)
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch (Exception)
            {

                throw new Exception(FALHA_AUTENTICACAO);
            }
        }

    }
}
