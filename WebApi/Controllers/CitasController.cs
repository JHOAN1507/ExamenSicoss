using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CitasController : ApiController
    {
        // GET: api/Citas
        public IEnumerable<Cita> Get()
        {
            return new HelperData().GetCitas();
        }

        // GET: api/Citas/5
        public Cita Get(int id)
        {
            return new HelperData().GetCita(id) ;
        }
      

        // POST: api/Citas
        public void Post([FromBody]Cita value)
        {
            new HelperData().InsertCita(value);
        }

        // PUT: api/Citas/5
        public void Put(int id, [FromBody]Cita value)
        {
            new HelperData().UpdateCitas(value);
        }
        public Cita GetLazy(int id)
        {
            return new HelperData().GetCitaLazy(id);
        }

        // DELETE: api/Citas/5
        public void Delete(int id)
        {

            new HelperData().DeletedCita(GetLazy(id));
        }
    }
}
