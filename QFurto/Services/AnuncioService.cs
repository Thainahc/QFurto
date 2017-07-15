using QFurto.Controllers.Enums;
using QFurto.Models.Entities;
using QFurto.Models.Enums;
using QFurto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QFurto.Services
{
    public class AnuncioService
    {
        ResponseService ResponseService;
        private readonly DataContext dataContext;
        private readonly AnuncioRepository anuncioRepository;

        public AnuncioService()
        {
            dataContext = new DataContext();
            ResponseService = new ResponseService();
            anuncioRepository = new AnuncioRepository();
        }

        public string ResponseType
        {
            get
            {
                return ResponseService.Type.ToString();
            }
        }

        public string ResponseMessage
        {
            get
            {
                return ResponseService.Message;
            }
        }

        public List<string> FieldsInvalids
        {
            get
            {
                return ResponseService.FieldsInvalids;
            }
        }

        public void Add(Anuncio anuncio)
        {
            try
            {
                dataContext.BeginTransaction();
                if (ValidaAnuncio(anuncio))
                {
                    anuncioRepository.Add(anuncio);
                    dataContext.Commit();
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Anúncio cadastrado com sucesso."
                    };
                }
            }
            catch (Exception ex)
            {
                dataContext.Rollback();
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Erro ao cadastrar anúncio."
                };
            }
            finally
            {
                dataContext.Finally();
            }
        }

        public bool ValidaAnuncio(Anuncio anuncio)
        {
            ResponseService = new ResponseService();
            if (string.IsNullOrEmpty(anuncio.NomePessoa))
            {
                ResponseService.FieldsInvalids.Add("NomePessoa");
            }
            if (anuncio.VeiculoTipo == VeiculoEnum.None)
            {
                ResponseService.FieldsInvalids.Add("VeiculoTipo");
            }
            if (string.IsNullOrEmpty(anuncio.Modelo))
            {
                ResponseService.FieldsInvalids.Add("Modelo");
            }
            if (anuncio.Bairro == BairroEnum.None)
            {
                ResponseService.FieldsInvalids.Add("Bairro");
            }
            if (string.IsNullOrEmpty(anuncio.Telefone))
            {
                ResponseService.FieldsInvalids.Add("Telefone");
            }
            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message = "Informe os dados corretamente.";
            }
            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                    ResponseTypeEnum.Success :
                    ResponseTypeEnum.Warning;
            return ResponseService.Type == ResponseTypeEnum.Success;
        }
    }
}