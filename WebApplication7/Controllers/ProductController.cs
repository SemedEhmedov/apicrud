using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.DAL;
using WebApplication7.DTOs;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDBContext _context;
        IMapper _mapper;
        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Products.FirstOrDefault(x => x.Id == id);
            return category == null ? NotFound() : Ok(category);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpPost]
        public ObjectResult Create(CreateProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO product)
        {
            var oldProduct= _context.Products.AsNoTracking().FirstOrDefault(x=>x.Id==product.Id);
            if (oldProduct == null) return NotFound();
            oldProduct = _mapper.Map<Product>(product);
            _context.Products.Update(oldProduct);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
