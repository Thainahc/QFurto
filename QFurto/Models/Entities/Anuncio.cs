using QFurto.Controllers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QFurto.Models.Entities
{
    public class Anuncio
    {
        public int AnuncioId { get; set; }
        public DateTime DataHora { get; set; }
        public string NomePessoa { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public BairroEnum Bairro { get; set; }
        public VeiculoEnum VeiculoTipo { get; set; }
        public byte[] VeiculoFoto { get; set; }
    }
}