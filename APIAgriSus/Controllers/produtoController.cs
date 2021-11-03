using APIAgriSus.Data;
using APIAgriSus.Models;
using APIAgriSus.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class produtoController : ControllerBase
    {
        [HttpGet]
        [Route("produto")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var produtos = await context
                .Produto
                .AsNoTracking()
                .ToListAsync();


            foreach(Produto item in produtos)
            {
                var agricultor = await context
                        .Agricultores
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.id == item.AgricultorId);

                item.Agricultor = agricultor;
            }


            return Ok(produtos);
        }


        [HttpGet]
        [Route("produto/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var produto = await context
                .Produto
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                var agricultor = await context
                        .Agricultores
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.id == produto.AgricultorId);

                produto.Agricultor = agricultor;

                return Ok(produto);
            }
        }

        [HttpPost]
        [Route("produto")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] ProdutoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newProduto = new Produto
            {
                nome = model.nome,
                quantidade = model.quantidade,
                valor = model.valor,
                AgricultorId = model.AgricultorId,
                descricao = model.descricao
            };

            try
            {
                await context.Produto.AddAsync(newProduto);
                await context.SaveChangesAsync();
                return Created($"/api/pequenoAgricultor/agricultor/{newProduto.id}", newProduto);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("produto/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] ProdutoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var produto = await context.Produto.FirstOrDefaultAsync(x => x.id == id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                produto.nome = model.nome;
                produto.valor = model.valor;
                produto.quantidade = model.quantidade;
                produto.descricao = model.descricao;

                context.Produto.Update(produto);
                await context.SaveChangesAsync();
                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("produto/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var produto = await context.Produto.FirstOrDefaultAsync(x => x.id == id);

            if (produto == null)
            {
                return NotFound();
            }

            try
            {
                context.Produto.Remove(produto);
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
