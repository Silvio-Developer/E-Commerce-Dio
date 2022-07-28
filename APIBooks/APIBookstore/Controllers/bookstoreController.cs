using APIBookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly TodoContext _context;



        public bookstoreController(TodoContext context)
        {

            _context = context;

            foreach (Product x in _context.TodoProducts)
                _context.TodoProducts.Remove(x);
            _context.SaveChanges();


            _context.TodoProducts.Add(new Product { Id = "1", Name = "Código Limpo", Price = 59.90, Quantity = 10, Category = "Programação", Img = "img1" });
            _context.TodoProducts.Add(new Product { Id = "2", Name = "O Mundo de Sofia", Price = 50.89, Quantity = 1, Category = "Ação", Img = "img2" });
            _context.TodoProducts.Add(new Product { Id = "3", Name = "Refatoração", Price = 60, Quantity = 2, Category = "Programação", Img = "img3" });
            _context.TodoProducts.Add(new Product { Id = "4", Name = "Introdução à Programação", Price = 90, Quantity = 1, Category = "Programação", Img = "img4" });
            _context.TodoProducts.Add(new Product { Id = "5", Name = "Programação para Leigos", Price = 105, Quantity = 5, Category = "Programação", Img = "img5" });
            _context.TodoProducts.Add(new Product { Id = "6", Name = "Desenvolvimento com AngularJS", Price = 50.8, Quantity = 2, Category = "Programação", Img = "img6" });
            _context.TodoProducts.Add(new Product { Id = "7", Name = "Python", Price = 59.99, Quantity = 10, Category = "Programação", Img = "img7" });
            _context.SaveChanges();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.TodoProducts.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, product);
        }

        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTodoItems()
        {
            return await _context.TodoProducts.ToListAsync(); 



        }

        // GET: api/bookstore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var todoItem = await _context.TodoProducts.FindAsync(id.ToString());

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

    }
}
