using MKT.Logica;
using MKT.Logica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MKT.WebAPIRest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GerentesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/Gerentes/GetAllGerentes/")]
        public IHttpActionResult GetAllGerentes()
        {
            return Ok(DataManager.GetAllGerentes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dO_Gerente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Gerentes/InsertGerente/")]
        public IHttpActionResult InsertGerente(DO_Gerente dO_Gerente)
        {

            int r = DataManager.InsertGerente(dO_Gerente);

            if (r > 0)
            {
                return Ok("El registro se guardó exitosamente");
            }
            else
            {
                return BadRequest("Ups!, por favor intente mas tarde.");
            }
        }


    }
}
