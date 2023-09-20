using Microsoft.AspNetCore.Mvc;
using Udlejningsmaskineoversigt.Src.Enumerators;
using Udlejningsmaskineoversigt.Src.Interfaces;
using Udlejningsmaskineoversigt.Src.Models;
using Udlejningsmaskineoversigt.Src.Services;

namespace Udlejningsmaskineoversigt.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class RessourceController : ControllerBase {

        private readonly static IRessourceRepository _repo = new RessourceRepository();

        [HttpPost]
        public ActionResult CreateNewRessource(string desc, int spec, double price) {

            Ressource result = new Ressource(desc, (Specification)spec, price);
            _repo.Add(result);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ressource> GetRessource(int id) {
            Ressource result = _repo.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateRessouce(int id, string desc, int spec, double price) {

            Ressource result = new Ressource(id, desc, (Specification)spec, price);
            _repo.Update(result);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteRessouce(int id) {

            _repo.Delete(id);

            return Ok();
        }

    }
}
