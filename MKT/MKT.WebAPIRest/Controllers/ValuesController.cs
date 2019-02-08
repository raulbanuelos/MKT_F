using MKT.WebAPIRest.Models;
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
    [Authorize]
    public class ValuesController : ApiController
    {
        private Gerente[] lista => new Gerente[] { new Gerente { Id = 1, Nombre = "Raúl"},
                                        new Gerente{ Id = 2, Nombre = "Armando"},
                                        new Gerente{ Id = 3, Nombre = "Lizeth"} };
        //return new Gerente[0];

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Gerente> Get()
        {
            return lista;
        }

        /// <summary>
        /// Get element by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gerente Get(int id)
        {
            return lista[id];
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]Gerente value)
        {
            lista[id] = value;
        }


        /// <summary>
        /// Mal Request
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/values/GetAllValues/")]
        public IHttpActionResult GetAllValues()
        {
            if (lista.Length > 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }
            
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }

}
