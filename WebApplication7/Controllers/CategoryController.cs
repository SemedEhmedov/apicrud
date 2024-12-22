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
    public class CategoryController : ControllerBase
    {
        AppDBContext _context;
        IMapper _mapper;
        public CategoryController(AppDBContext context)
        {
            _context = context;
        }

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return category == null ? NotFound() : Ok(category);
        }
        public IActionResult GetAll()
        {
            return Ok(_context.Categories.ToList());
        }
        [HttpPost]
        public ObjectResult Create(CreateCategoryDTO category)
        {
            var newCategory = _mapper.Map<Category>(category);
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newCategory);
        }
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (Category == null)
            {
                NotFound();
            }
            _context.Categories.Remove(Category);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent, Category);
        }
        public async Task<IActionResult> Update(UpdateCategoryDTO category)
        {
            var oldCategories = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == category.Id);
            if (oldCategories == null) return NotFound();
            oldCategories = _mapper.Map<Category>(category);
            _context.Categories.Update(oldCategories);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
