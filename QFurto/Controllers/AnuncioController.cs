using QFurto.Models.Entities;
using QFurto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace QFurto.Controllers
{
    public class AnuncioController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AdicionaOuAtualizaAnuncio(Anuncio anuncio)
        {
            try
            {
                AnuncioService anuncioService = new AnuncioService();
                anuncioService.AddOrUpdate(anuncio);
                if (anuncioService.ResponseType.Equals("Error"))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, anuncioService.ResponseMessage);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = anuncioService.ResponseMessage,
                        Type = anuncioService.ResponseType,
                        FieldsInvalids = anuncioService.FieldsInvalids
                    });
                }
            }
            catch (Exception ex)
            {

            }
            return Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, "Erro ao cadastrar anuncio.");
        }
    }
}