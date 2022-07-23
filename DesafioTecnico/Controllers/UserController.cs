using AutoMapper;
using DesafioTecnico.Data;
using DesafioTecnico.Data.Dtos;
using DesafioTecnico.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo;
        private IMapper _mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);

                if (_userRepo.GetByCpf(user.UserCPF) == null)
                {
                    user.UserDataCriacao = DateTime.Now.ToString("dd-MM-yyyy");
                    _userRepo.Creat(user);
                    if (_userRepo.SaveChanges())
                    {
                        return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
                    }
                    return BadRequest("Falha ao salvar");
                }
                return BadRequest("Cpf já cadastrado");

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
            
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                User user = _userRepo.GetById(id);

                if (User != null)
                {
                    ReaderUserDto userDto = _mapper.Map<ReaderUserDto>(user);
                    return Ok(userDto);
                }
                return NotFound();

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                User user = _userRepo.GetById(id);
                if (user == null)
                {
                    return NotFound("Id não encontrado");
                }
                _mapper.Map(userDto, user);
                if (_userRepo.SaveChanges())
                {
                    return Ok(user);
                }
                return BadRequest("Falha ao salvar");

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletUser(int id)
        {
            try
            {
                User user = _userRepo.GetById(id);
                if (user == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                _userRepo.Delete(user);
                if (_userRepo.SaveChanges())
                {
                    return Ok(user);
                }
                return BadRequest("Falha ao salvar");
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("ativos")]
        public IActionResult GetAtivo()
        {
            try
            {
                IEnumerable<User> users = _userRepo.GetAtivos();

                if (users != null)
                {
                    IEnumerable<ReaderUserDto> userDto = _mapper.Map<IEnumerable<ReaderUserDto>>(users);
                    return Ok(userDto);
                }
                return NotFound("Nenhum usuario ativo");

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }
    }
}
