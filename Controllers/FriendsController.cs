using AddressBookWebAPI.Models;
using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {

        private readonly IDataRepository<Friend> _dataRepository;
        public FriendsController(IDataRepository<Friend> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<FriendsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var friends = _dataRepository.GetAll();
            return Ok(friends);
        }

        // GET api/<FriendsController>/5
        [HttpGet("{id}", Name = "GetFriend")]
        public IActionResult Get(int id)
        {
            // Get(id) returns the friend entity based on the FriendId column
            var friend = _dataRepository.Get(id);
            if (friend == null)
            {
                return NotFound("Friend not found.");
            }
            return Ok(friend);
        }

        // POST: api/Friends
        [HttpPost]
        public IActionResult Post([FromBody] Friend friend)
        {
            if (friend is null)
            {
                return BadRequest("Friend is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(friend);
            return NoContent();
        }

        // PUT: api/friends/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Friend friend)
        {
            if (friend == null)
            {
                return BadRequest("Friend is null.");
            }
            var friendToUpdate = _dataRepository.Get(id);
            if (friendToUpdate == null)
            {
                return NotFound("The Friend record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(friendToUpdate, friend);
            return NoContent();
        }

        // DELETE api/parents/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Not a valid friend id");
            }
            var friendToDelete = _dataRepository.Get(id);
            if (friendToDelete == null)
            {
                return NotFound("The friend record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Delete(friendToDelete);
            return NoContent();
        }
    }
}
