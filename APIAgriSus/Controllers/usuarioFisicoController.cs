using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAgriSus.Models;
using APIAgriSus.Data;
using Microsoft.EntityFrameworkCore;
using APIAgriSus.ViewModels;

namespace APIAgriSus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usuarioFisico : Controller
    {

        [HttpGet]
        [Route("usuarioFisico")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var userFisico = await context
                .Userfisico
                .AsNoTracking()
                .ToListAsync();
            return Ok(userFisico);
        }
        [HttpGet]
        [Route("usuarioFisico/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var userFisico = await context
                .Userfisico
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (userFisico == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userFisico);
            }
        }
        [HttpPost]
        [Route("usuarioFisico")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] userfisicoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newUserFisico = new Userfisico();
            {

                newUserFisico.nome = model.nome;
                newUserFisico.cpf = model.cpf;
                newUserFisico.endereco = model.endereco;
                newUserFisico.telefone = model.telefone;
                newUserFisico.senha = model.senha;


            };

            try
            {
                await context.Userfisico.AddAsync(newUserFisico);
                await context.SaveChangesAsync();
                return Created($"/api/usuarioFisico/userfisico/{newUserFisico.id}", newUserFisico);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("userfisico/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] userfisicoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userfisico = await context.Userfisico.FirstOrDefaultAsync(x => x.id == id);

            if (userfisico == null)
            {
                return NotFound();
            }

            try
            {
                userfisico.nome = model.nome;
                userfisico.endereco = model.endereco;
                userfisico.cpf = model.cpf;
                userfisico.telefone = model.telefone;
                userfisico.senha = model.senha;

                context.Userfisico.Update(userfisico);
                await context.SaveChangesAsync();
                return Ok(userfisico);
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("userfisico/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var userfisico = await context.Userfisico.FirstOrDefaultAsync(x => x.id == id);

            if (userfisico == null)
            {
                return NotFound();
            }

            try
            {
                context.Userfisico.Remove(userfisico);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
