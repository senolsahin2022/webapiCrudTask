using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sunum2.API.Models;
using sunum2.API.Repository.Interfaces;

namespace sunum2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _UserRepository.GetUsers());
        }

        [HttpGet]
        [Route("GetUserByID/{ID}")]
        public async Task<IActionResult> GetUserByID(int ID)
        {
            return Ok(await _UserRepository.GetUserByID(ID));
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User User)
        {
            await _UserRepository.CreateUser(User);
            return Ok("Added successfully!");
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User User)
        {
            await _UserRepository.UpdateUser(User);
            return Ok("Updated successfully!");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult DeleteUser(int ID)
        {
            _UserRepository.DeleteUser(ID);
            return new JsonResult(true);
        }
    }
}
