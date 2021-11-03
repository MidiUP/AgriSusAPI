using APIAgriSus.Data;
using APIAgriSus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAgriSus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class loginController : ControllerBase
    {
        
        
        [HttpPost]
        [Route("agricultor")]
        public async Task<IActionResult> Login(
            [FromServices] AppDbContext context,
            [FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var agricultor = await context
                        .Agricultores
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.cnpj == model.login);

            if(agricultor == null)
            {
                return BadRequest();
            }

            if(agricultor.senha != model.senha)
            {
                return BadRequest();
            }

            return Ok(true);
        }


        [HttpPost]
        [Route("pessoaJuridica")]
        public async Task<IActionResult> LoginPessoaJuridica(
            [FromServices] AppDbContext context,
            [FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoaJurudica = await context
                        .UserJuridico
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.cnpj == model.login);

            if (pessoaJurudica == null)
            {
                return BadRequest();
            }

            if (pessoaJurudica.senha != model.senha)
            {
                return BadRequest();
            }

            return Ok(true);
        }


        [HttpPost]
        [Route("pessoaFisica")]
        public async Task<IActionResult> LoginPessoaFisica(
            [FromServices] AppDbContext context,
            [FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoaFisica = await context
                        .Userfisico
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.cpf == model.login);

            if (pessoaFisica == null)
            {
                return BadRequest();
            }

            if (pessoaFisica.senha != model.senha)
            {
                return BadRequest();
            }

            return Ok(true);
        }
    }
}
