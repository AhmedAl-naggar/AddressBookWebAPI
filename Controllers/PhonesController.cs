using AddressBookWebAPI.Models;
using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {

        private readonly IDataRepository<Phone> _dataRepository;
        public PhonesController(IDataRepository<Phone> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<PhonesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var phones = _dataRepository.GetAll();
            return Ok(phones);
        }

        // GET api/<PhonesController>/5
        [HttpGet("{id}", Name = "GetPhone")]
        public IActionResult Get(int id)
        {
            var phone = _dataRepository.Get(id);
            if (phone == null)
            {
                return NotFound("Phone not found.");
            }
            return Ok(phone);
        }

        // POST: api/Phones
        [HttpPost]
        public IActionResult Post([FromBody] Phone phone)
        {
            if (phone is null)
            {
                return BadRequest("Phone is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(phone);
            return NoContent();
        }

        // PUT: api/phones/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Phone phone)
        {
            if (phone == null)
            {
                return BadRequest("Phone is null.");
            }
            var phoneToUpdate = _dataRepository.Get(id);
            if (phoneToUpdate == null)
            {
                return NotFound("The Phone record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(phoneToUpdate, phone);
            return NoContent();
        }

        // DELETE api/Phones/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Not a valid user id");
            }
            var phoneToDelete = _dataRepository.Get(id);
            if (phoneToDelete == null)
            {
                return NotFound("The User record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Delete(phoneToDelete);
            return NoContent();
        }
    }
}
