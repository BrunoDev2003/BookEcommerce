using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livrariaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context) {
            _context = context;

            _context.todoProducts.Add(new Produto {ID = "1", Nome = "livro1", Preco = (int)24.0, Categoria = "Ação", Img = "mg1" });
            _context.todoProducts.Add(new Produto {ID = "2", Nome = "livro2", Preco = (int)24.0, Categoria = "Ação", Img = "mg2" });
            _context.todoProducts.Add(new Produto {ID = "3", Nome = "livro3", Preco = (int)24.0, Categoria = "Ação", Img = "mg3" });
            _context.todoProducts.Add(new Produto {ID = "4", Nome = "livro4", Preco = (int)24.0, Categoria = "Ação", Img = "mg4" });
            _context.todoProducts.Add(new Produto {ID = "5", Nome = "livro5", Preco = (int)24.0, Categoria = "Ação", Img = "mg5" });
            _context.todoProducts.Add(new Produto {ID = "6", Nome = "livro6", Preco = (int)24.0, Categoria = "Ação", Img = "mg6" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos() 
        {
            return await _context.todoProducts.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>>GetItem(int id) 
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if(item == null) {
                return NotFound();
            } 
            return item;
            
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto) 
        {
            _context.todoProducts.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto),new{id = produto.id}, produto);
        }

        private object GetProduto()
        {
            throw new NotImplementedException();
        }
    }
}