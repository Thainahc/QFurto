using MySql.Data.MySqlClient;
using QFurto.Controllers.Enums;
using QFurto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
            query.Append(" VeiculoTipo,         ");
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
            query.Append(" ?VeiculoTipo,        ");
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

        public void Update(Anuncio anuncio)
        {
            var query = new StringBuilder();
            query.Append(" UPDATE anuncios SET ");
            query.Append(" NomePessoa  =  ?NomePessoa, ");
            query.Append(" VeiculoTipo = ?VeiculoTipo, ");
            query.Append(" Modelo      = ?Modelo,      ");
            query.Append(" Placa = ?Placa,             ");
            query.Append(" Ano = ?Ano,                 ");
            query.Append(" Bairro = ?Bairro,           ");
            query.Append(" Descricao = ?Descricao,     ");
            query.Append(" Telefone = ?Telefone        ");
            query.Append(" WHERE                       ");
            query.Append(" AnuncioId = ?AnuncioId      ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?AnuncioId", anuncio.AnuncioId);
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

        public Anuncio Select(int anuncioId)
        {
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT * FROM Anuncios ");
            query.Append(" WHERE                  ");
            query.Append(" AnuncioId = ?AnuncioId ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?AnuncioId", anuncioId);
            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var anuncio = new Anuncio()
                {
                    AnuncioId = Convert.ToInt32(row["AnuncioId"]),
                    DataHora = Convert.ToDateTime(row["DataHora"]),
                    NomePessoa = row["NomePessoa"].ToString(),
                    VeiculoTipo = (VeiculoEnum)row["VeiculoTipo"],
                    Modelo = row["Modelo"].ToString(),
                    Placa = row["Placa"].ToString(),
                    Ano = Convert.ToInt32(row["Ano"]),
                    Bairro = (BairroEnum)row["Bairro"],
                    Descricao = row["Descricao"].ToString(),
                    Telefone = row["Telefone"].ToString()
                };
                return anuncio;
            }
            return new Anuncio();
        }
    }
}