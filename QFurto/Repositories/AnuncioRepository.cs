using MySql.Data.MySqlClient;
using QFurto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QFurto.Repositories
{
    public class AnuncioRepository
    {
        public void Add(Anuncio anuncio)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO anuncios ");
            query.Append(" (                    ");
            query.Append(" DataHora,            ");
            query.Append(" NomePessoa,          ");
            query.Append(" TipoVeiculo,         ");
            query.Append(" Modelo,              ");
            query.Append(" Placa,               ");
            query.Append(" Ano,                 ");
            query.Append(" Bairro,              ");
            query.Append(" Descricao,           ");
            query.Append(" Telefone             ");
            query.Append(" )                    ");
            query.Append(" VALUES               ");
            query.Append(" (                    ");
            query.Append(" ?DataHora,           ");
            query.Append(" ?NomePessoa,         ");
            query.Append(" ?TipoVeiculo,        ");
            query.Append(" ?Modelo,             ");
            query.Append(" ?Placa,              ");
            query.Append(" ?Ano,                ");
            query.Append(" ??Bairro,            ");
            query.Append(" ?Descricao,          ");
            query.Append(" ?Telefone            ");
            query.Append(" )                    ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?DataHora", DateTime.Now);
            mySqlCommand.Parameters.AddWithValue("?NomePessoa", anuncio.NomePessoa);
            mySqlCommand.Parameters.AddWithValue("?VeiculoTipo", anuncio.VeiculoTipo);
            mySqlCommand.Parameters.AddWithValue("?Modelo", anuncio.Modelo);
            mySqlCommand.Parameters.AddWithValue("?Placa", anuncio.Placa);
            mySqlCommand.Parameters.AddWithValue("?Ano", anuncio.Ano);
            mySqlCommand.Parameters.AddWithValue("?Bairro", anuncio.Bairro);
            mySqlCommand.Parameters.AddWithValue("?Descricao", anuncio.Descricao);
            mySqlCommand.Parameters.AddWithValue("?Telefone", anuncio.Telefone);
            mySqlCommand.ExecuteNonQuery();
        }
    }
}