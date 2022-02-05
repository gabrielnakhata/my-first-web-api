﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace my_first_web_api.Controllers.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "dbcliente";
        private static string User = "root";
        private static string Password = "099006";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;";

        public DAL() {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        //Executa: INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        //Retorna Dados do Banco
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdaptar = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptar.Fill(Dados);
            return Dados;
        }
    }
}
