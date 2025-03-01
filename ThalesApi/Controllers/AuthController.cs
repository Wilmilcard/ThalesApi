using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using ThalesApi.Domain.Models;
using ThalesApi.Domain;
using ThalesApi.Domain.DB;
using ThalesApi.HttpRequest;
using ThalesApi.Utils;
using ThalesApi.Interfaces;

namespace ThalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ThalesContext _context;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public AuthController(ThalesContext context, IUserServices userServices, IConfiguration configuration)
        {
            _context = context;
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password))
                return new BadRequestObjectResult(new { success = false, data = "El usuario y/o contraseña estan vacios" });

            var user = _userServices.QueryNoTracking().Where(x => x.Username == request.username).FirstOrDefault();
            if (user == null)
                return new BadRequestObjectResult(new { success = false, data = "El usuario no se encuentra registrado" });

            var pass = Encrypt.MD5(request.password);

            //Tiempo de Token
            var expiration_date = Globals.SystemDate().AddHours(5).AddHours(8);//8 horas de vida para el token
            var jwtHelper = new JWTHelper(this._configuration.GetValue<string>("SecurityKey"));
            var token = jwtHelper.CreateToken(request.username, expiration_date);

            //Validamos la sesion
            var _sesion = _context.sesiones
                .Where(x => x.UserId == user.UserId)
                .FirstOrDefault();

            if (_sesion == null)
            {
                var sesion = new Sesion
                {
                    UserId = user.UserId,
                    Token = token,
                    Expiration_Date = expiration_date,
                    creationAt = Globals.SystemDate()
                };
                _context.sesiones.Add(sesion);

                user.updatedAt = Globals.SystemDate();
                await _userServices.UpdateAsync(user);

                _sesion = _context.sesiones.Where(x => x.UserId == user.UserId).FirstOrDefault();
            }
            else
            {
                _sesion.Token = token;
                _sesion.Expiration_Date = expiration_date;
                _sesion.updatedAt = Globals.SystemDate();
                _context.sesiones.Update(_sesion);
            }

            user.updatedAt = Globals.SystemDate();
            await _userServices.UpdateAsync(user);

            _context.SaveChanges();

            var response = new
            {
                success = true,
                data = new
                {
                    _sesion.User.Username,
                    token
                },
            };

            return new OkObjectResult(response);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] LoginRequest request)
        {
            var newUser = new User
            {
                Username = request.username,
                PasswordHash = Encrypt.MD5(request.password),
                creationAt = Utils.Globals.SystemDate()
            };

            await _userServices.AddAsync(newUser);

            var response = new
            {
                succcess = true,
                data = "Proceso terminado"
            };

            return new OkObjectResult(response);
        }
    }
}
