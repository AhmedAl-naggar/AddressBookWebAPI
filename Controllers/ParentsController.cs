using AddressBookWebAPI.Models;
using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {

        private readonly IDataRepository<Parent> _dataRepository;
        public ParentsController(IDataRepository<Parent> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<ParentsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var parents = _dataRepository.GetAll();
            return Ok(parents);
        }

        // GET api/<ParentsController>/5
        [HttpGet("{id}", Name = "GetParent")]
        public IActionResult Get(int id)
        {
            var parent = _dataRepository.Get(id);
            if (parent == null)
            {
                return NotFound("Parent not found.");
            }
            return Ok(parent);
        }

        // POST: api/Parents
        [HttpPost]
        public IActionResult Post([FromBody] Parent parent)
        {
            if (parent is null)
            {
                return BadRequest("Parent is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(parent);
            return NoContent();
        }

        // PUT: api/parents/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Parent parent)
        {
            if (parent == null)
            {
                return BadRequest("Parent is null.");
            }
            var parentToUpdate = _dataRepository.Get(id);
            if (parentToUpdate == null)
            {
                return NotFound("The Parent record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(parentToUpdate, parent);
            return NoContent();
        }

        // DELETE api/parents/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Not a valid parent id");
            }
            var parentToDelete = _dataRepository.Get(id);
            if (parentToDelete == null)
            {
                return NotFound("The parent record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Delete(parentToDelete);
            return NoContent();
        }
    }
}
