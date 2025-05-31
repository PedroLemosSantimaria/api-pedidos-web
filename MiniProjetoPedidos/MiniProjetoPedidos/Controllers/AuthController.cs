using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniProjetoPedidos.Auxiliares;
using MiniProjetoPedidos.Data;
using MiniProjetoPedidos.Models;
using MiniProjetoPedidos.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniProjetoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UsuarioRepository _repo;

        public AuthController(IConfiguration config)
        {
            _config = config;
            _repo = new UsuarioRepository();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Usuário e senha são obrigatórios.");

            if (_repo.BuscarUsuario(request.Username) != null)
                return BadRequest("Usuário já existe.");

            var usuario = new Usuario
            {
                Username = request.Username,
                PasswordHash = PasswordHelper.Hash(request.Password)
            };

            _repo.AdicionarUsuario(usuario);
            return Ok("Usuário cadastrado com sucesso.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _repo.BuscarUsuario(request.Username);

            if (usuario == null || !PasswordHelper.Verificar(request.Password, usuario.PasswordHash))
                return Unauthorized("Usuário ou senha inválidos.");

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario.Username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
