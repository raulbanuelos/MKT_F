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
        /// Obtener todos los gerentes.
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/Gerentes/GetAllGerentes/")]
        public IHttpActionResult GetAllGerentes()
        {
            return Ok(DataManager.GetAllGerentes());
        }

        /// <summary>
        /// Insertar gerente.
        /// </summary>
        /// <param name="dO_Gerente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Gerentes/InsertGerente/")]
        public IHttpActionResult InsertGerente(DO_Gerente dO_Gerente)
        {
            if (DataManager.ExistGerente(dO_Gerente.CodigoNomina))
            {
                return BadRequest("El código de nomina es repetido, favor de ingresa otro.");
            }
            else
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

        /// <summary>
        /// Actualizar datos de gerente.
        /// </summary>
        /// <param name="dO_Gerente"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Gerentes/UpdateGerente/")]
        public IHttpActionResult UpdateGerente(DO_Gerente dO_Gerente)
        {
            int r = DataManager.UpdateGerente(dO_Gerente);

            if (r > 0)
            {
                return Ok("Registro actualizado correctamente");
            }
            else
            {
                return BadRequest("Ups!, por favor intenta mas tarde.");
            }
        }

        /// <summary>
        /// Eliminar Gerente
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Gerentes/DeleteGerente")]
        public IHttpActionResult DeleteGerente(int idGerente)
        {
            int r = DataManager.DeleteGerente(idGerente);

            if (r > 0)
            {
                return Ok("Registro eliminado correctamente");
            }
            else
            {
                return BadRequest("Ups!, por favor intenta mas tarde.");
            }
        }
    }
}
