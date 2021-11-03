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
    public class pequenoAgricultorController : ControllerBase
    {
       

        [HttpGet]
        [Route("agricultor")]
        public async Task<IActionResult> GetAsync(
            [FromServices]AppDbContext context)
        {
            var agricultores = await context
                .Agricultores
                .AsNoTracking()
                .ToListAsync();
            return Ok(agricultores);
        }

        [HttpGet]
        [Route("agricultor/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute]int id)
        {
            var agricultor = await context
                .Agricultores
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if(agricultor == null)
            {
                return NotFound();
            }else
            {
                return Ok(agricultor);
            }
        }

        [HttpPost]
        [Route("agricultor")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody]AgricultorViewModel model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newAgricultor = new Agricultor
            {

                nome = model.nome,
                cnpj = model.cnpj,
                endereco = model.endereco,
                telefone = model.telefone,
                avaliacao = 0,
                numeroDeAvaliacao = 0,
                motivacao = model.motivacao,
                senha = model.senha,
                imagem = ""

            };

            try
            {
                await context.Agricultores.AddAsync(newAgricultor);
                await context.SaveChangesAsync();
                return Created($"/api/pequenoAgricultor/agricultor/{newAgricultor.id}", newAgricultor);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("agricultor/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] AgricultorViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var agricultor = await context.Agricultores.FirstOrDefaultAsync(x => x.id == id);

            if(agricultor == null)
            {
                return NotFound();
            }

            try
            {
                agricultor.nome = model.nome;
                agricultor.endereco = model.endereco;
                agricultor.cnpj = model.cnpj;
                agricultor.imagem = model.imagem;
                agricultor.motivacao = model.motivacao;
                agricultor.senha = model.senha;
                agricultor.telefone = model.telefone;

                context.Agricultores.Update(agricultor);
                await context.SaveChangesAsync();
                return Ok(agricultor);
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("agricultor/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var agricultor = await context.Agricultores.FirstOrDefaultAsync(x => x.id == id);

            if (agricultor == null)
            {
                return NotFound();
            }

            try
            {
                context.Agricultores.Remove(agricultor);
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
