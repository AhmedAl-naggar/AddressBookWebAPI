using AddressBookWebAPI.Models;
using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IDataRepository<User> _dataRepository;
        public UsersController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            var user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("User is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(user);
            return NoContent();
        }

        // PUT: api/users/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            var userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid user id");
            }
            var userToDelete = _dataRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Delete(userToDelete);
            return NoContent();
        }
    }
}
