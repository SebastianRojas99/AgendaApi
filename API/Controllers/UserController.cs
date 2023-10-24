using AgendaApi.Data.Repository.Implementations;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOneById(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            User? user = _userRepository.GetById(Id);

            if (user is null)
            {
                return NotFound();
            }

            var dto = new GetUserByIdResponse()
            {
                Apellido = user.LastName,
                Nombre = user.FirstName,
                NombreDeUsuario = user.UserName,
                Estado = user.State,
                Id = user.Id,
                Contactos = user.Contacts,
                Rol = user.Rol
            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpPut]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            User? user = _userRepository.GetById(id);
            if (user is null)
            {
                return BadRequest("El cliente que intenta eliminar no existe");
            }

            if (user.FirstName != "Admin")
            {
                _userRepository.Delete(id);
            }
            else
            {
                _userRepository.Archive(id);
            }
            return NoContent();
        }
    }
}
