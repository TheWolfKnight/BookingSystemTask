using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Abstraction.Enumerators;
using Abstraction.Interfaces;
using Abstraction.Models;
using Udlejningsmaskineoversigt.Src.Services;

namespace Udlejningsmaskineoversigt.Controllers {
    /// <summary>
    /// The controller for the Resource api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RessourceController : ControllerBase {

        private readonly static IRescourceRepository _repo = new RessourceRepository();

        /// <summary>
        /// Creates a new element in the database
        /// </summary>
        /// <param name="source"> the data for the new element </param>
        /// <returns> An ActionResult </returns>
        [HttpPost]
        [Description("Test")]
        public ActionResult CreateNewRessource([FromBody] ResourceDTO source) {
            _repo.Add(source);
            return Ok();
        }

        /// <summary>
        /// Gets a specific resource from the database by id
        /// </summary>
        /// <param name="id"> The id of the resource to be updated </param>
        /// <returns> An instance of RescourceDTO or an ActionResult error </returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResourceDTO> GetRessource(int id) {
            try {
                ResourceDTO result = _repo.GetById(id);
                return Ok(result);
            } catch (Exception) {
                return new NoContentResult();
            }
        }

        /// <summary>
        /// Updates a specific resource from the database
        /// </summary>
        /// <param name="id"> The id for the item to be updated </param>
        /// <param name="source"> The data for the update </param>
        /// <returns> An ActionResult </returns>
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateRessouce(int id, [FromBody] ResourceDTO source) {
            ResourceDTO result = new ResourceDTO(id, source);
            try {
                _repo.Update(result);
                return Ok();
            } catch (Exception) {
                return new NoContentResult();
            }
        }

        /// <summary>
        /// Removes a specific resource from the database by id
        /// </summary>
        /// <param name="id"> The id for the element to be changed </param>
        /// <returns> An ActionResult </returns>
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
