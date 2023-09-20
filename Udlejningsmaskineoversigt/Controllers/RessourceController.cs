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
        public ActionResult CreateNewRessource([FromBody] RessourceDTO source) {
            _repo.Add(source);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ressource> GetRessource(int id) {
            try {
                Ressource result = _repo.GetById(id);
                return Ok(result);
            } catch (Exception) {
                return new NoContentResult();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateRessouce(int id, [FromBody] RessourceDTO source) {
            RessourceDTO result = new RessourceDTO(id, source);
            try {
                _repo.Update(result);
                return Ok();
            } catch (Exception) {
                return new NoContentResult();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteRessouce(int id) {
            try {
                _repo.Delete(id);
                return Ok();
            } catch (Exception) {
                return new NoContentResult();
            }
        }

    }
}
