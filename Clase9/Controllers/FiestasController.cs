using Clase9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Clase9.Controllers
{
    public class FiestasController : ApiController
    {
        private readonly Fiestas_ArgentinasEntities _db = new Fiestas_ArgentinasEntities();
        public FiestasController()
        {
                
        }

        public IEnumerable<Fiesta> Get()
        {
            return _db.Fiestas.ToList();
        }

        public Fiesta Get(int id)
        {
            return _db.Fiestas.Find(id);
        }
        public void  Post(Fiesta item)
        {
            _db.Fiestas.Add(item);
            _db.SaveChanges();
        }
        public async Task<StatusCodeResult> Put(Fiesta fiesta)
        {
            try
            {
                _db.Fiestas.Attach(fiesta);
                _db.Entry(fiesta).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.OK);
            }
            catch 
            {

                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
