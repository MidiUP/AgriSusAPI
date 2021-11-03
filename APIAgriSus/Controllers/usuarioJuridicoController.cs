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
    public class usuarioJuridico : Controller
    {

        [HttpGet]
        [Route("usuarioJuridico")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var userJuridico = await context
                .UserJuridico
                .AsNoTracking()
                .ToListAsync();
            return Ok(userJuridico);
        }
        [HttpGet]
        [Route("usuarioJuridico/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var userJuridico = await context
                .UserJuridico
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (userJuridico == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userJuridico);
            }
        }
        [HttpPost]
        [Route("usuarioJuridico")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] UserJuridicoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newuserJuridico = new UserJuridico
            {

                nomeUser = model.nomeUser,
                cnpj = model.cnpj,
                endereco = model.endereco,
                telefone = model.telefone


            };

            try
            {
                await context.UserJuridico.AddAsync(newuserJuridico);
                await context.SaveChangesAsync();
                return Created($"/api/usuarioJuridico/userJuridico/{newuserJuridico.id}", newuserJuridico);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("userJuridico" +
            "/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] UserJuridicoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userJuridico = await context.UserJuridico.FirstOrDefaultAsync(x => x.id == id);

            if (userJuridico == null)
            {
                return NotFound();
            }

            try
            {
                userJuridico.nomeUser = model.nomeUser;
                userJuridico.endereco = model.endereco;
                userJuridico.cnpj = model.cnpj;
                context.UserJuridico.Update(userJuridico);
                await context.SaveChangesAsync();
                return Ok(userJuridico);
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("userJuridico/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var userJuridico = await context.UserJuridico.FirstOrDefaultAsync(x => x.id == id);

            if (userJuridico == null)
            {
                return NotFound();
            }

            try
            {
                context.UserJuridico.Remove(userJuridico);
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