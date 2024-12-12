using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Dtos;
using prueba_tecnica.Models;
using prueba_tecnica.Repositories;
using prueba_tecnica.Services;


namespace prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbPruebaContext;
        private readonly AuthenticationService _utilidades;
        public AuthController(ApplicationDbContext dbPruebaContext, AuthenticationService utilidades)
        {
            _dbPruebaContext = dbPruebaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registrarse(UserRegister objeto)
        {

            var modeloUsuario = new User
            {
                Username = objeto.Username,
                Email = objeto.Email,
                Password = _utilidades.encriptarSHA256(objeto.Password)
            };

            await _dbPruebaContext.Users.AddAsync(modeloUsuario);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloUsuario.UserID != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbPruebaContext.Users
                                                    .Where(u =>
                                                        u.Email == objeto.Email &&
                                                        u.Password == _utilidades.encriptarSHA256(objeto.Password)
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
        }
    }

}
