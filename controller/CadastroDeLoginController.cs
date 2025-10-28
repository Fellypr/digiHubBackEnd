using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.data;
using BackEnd.model;
using BCrypt.Net;
namespace BackEnd.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroDeLogin : ControllerBase
    {
        private readonly AppDbContext _Dbcontext;
        public CadastroDeLogin(AppDbContext context)
        {
            _Dbcontext = context;
        }

        [HttpPost("login")]

        public async Task<ActionResult> Login([FromBody] Login user)
        {
            if (string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password))
            {
                return BadRequest("Preencha todos os Campos");
            }
            try
            {
                var userLogin = await _Dbcontext.Logins.FirstOrDefaultAsync(x => x.email == user.email);
                if (userLogin == null)
                {
                    return BadRequest("Ele é null");
                }
                if (BCrypt.Net.BCrypt.Verify(user.password, userLogin.password))
                {
                    return Ok("Login efetuado com sucesso");
                }
                else
                {
                    return BadRequest("Email ou Senha Incorretos");
                }
            }
            catch
            {
                return BadRequest("ERRO AO REALIZAR LOGIN");

            }

        }
        [HttpPost("Register")]

        public async Task<ActionResult> Register([FromBody] Login userRegister)
        {
            if (string.IsNullOrEmpty(userRegister.email) || string.IsNullOrEmpty(userRegister.password) || string.IsNullOrEmpty(userRegister.nameUser))
            {
                return BadRequest("Preencha todos os Campos");
            }
            try
            {

                var checkUser = await _Dbcontext.Logins.FirstOrDefaultAsync(x => x.email == userRegister.email);
                if (checkUser != null)
                {
                    return Conflict("Email já cadastrado");
                }
                var checkUserName = await _Dbcontext.Logins.FirstOrDefaultAsync(x => x.nameUser == userRegister.nameUser);
                if (checkUserName != null)
                {
                    return Conflict("Nome de Usuario ja cadastrado");
                }
                var searchUser = await _Dbcontext.Logins.FirstOrDefaultAsync(x => x.email == userRegister.email);
                if (searchUser == null)
                {
                    userRegister.password = BCrypt.Net.BCrypt.HashPassword(userRegister.password);
                    _Dbcontext.Logins.Add(userRegister);
                    await _Dbcontext.SaveChangesAsync();
                    return Ok("Cadastro efetuado com sucesso");
                }
                else
                {
                    return BadRequest("Email ja cadastrado");
                }

            }
            catch
            {
                return BadRequest("Email ou Senha Incorretos");
            }

        }

    }
}