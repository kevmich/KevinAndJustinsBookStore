using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KevinAndJustinsBookStore.Features;
using KevinAndJustinsBookStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KevinAndJustinsBookStore.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly DataContext dataContext;
        public InventoryController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        private static Expression<Func<Inventory, InventoryDto>> MapperMethod()
        {
            return x => new InventoryDto
            {
                Id = x.Id,
                Movies = x.Movies,
                Puzzels = x.Puzzels,
                Toys = x.Toys,
                Book = new BookDto
                {
                    Title = x.Book.Title,
                    Authors = x.Book.Authors,
                    Description = x.Book.Description,
                    Category = x.Book.Category,
                    ISBN = x.Book.ISBN,
                    DewyDec = x.Book.DewyDec,
                    Count = x.Book.Count
                },
            };
        }

        [HttpGet]
        public IEnumerable<InventoryDto> GetAll()
        {
            return dataContext.Set<Inventory>().Select(MapperMethod()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<InventoryDto> GetById(int id)
        {
            var data = dataContext.Set<Inventory>().Where(x => x.Id == id).Select(MapperMethod()).FirstOrDefault();

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public ActionResult<InventoryDto> Create(InventoryDto targetValue)
        {
            var data = dataContext.Set<Inventory>().Add(new Inventory
            {
                Book = new Book
                {
                    Title = targetValue.Book.Title,
                    Authors = targetValue.Book.Authors,
                    Description = targetValue.Book.Description,
                    Category = targetValue.Book.Category,
                    ISBN = targetValue.Book.ISBN,
                    DewyDec = targetValue.Book.DewyDec,
                    Count = targetValue.Book.Count
                },
                Movies = targetValue.Movies,
                Puzzels = targetValue.Puzzels,
                Toys = targetValue.Toys

            });
            dataContext.SaveChanges();
            targetValue.Id = data.Entity.Id;

            return Created($"/api/inventory/{data.Entity.Id}", targetValue);
        }

        [HttpPut("{id}")]
        public ActionResult<InventoryDto> Update(int id, InventoryDto targetValue)
        {
            var data = dataContext.Set<Inventory>().FirstOrDefault(x => x.Id == id);
            if(data == null)
            {
                return NotFound();
            }
            data.Movies = targetValue.Movies;
            data.Puzzels = targetValue.Puzzels;
            data.Toys = targetValue.Toys;
            data.Book = new Book
            {
                Title = targetValue.Book.Title,
                Authors = targetValue.Book.Authors,
                Description = targetValue.Book.Description,
                Category = targetValue.Book.Category,
                ISBN = targetValue.Book.ISBN,
                DewyDec = targetValue.Book.DewyDec,
                Count = targetValue.Book.Count

            };
            dataContext.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public ActionResult<InventoryDto> Delete(int id)
        {
            var data = dataContext.Set<Inventory>().FirstOrDefault(x => x.Id == id);
            if(data == null)
            {
                return NotFound();
            }

            dataContext.Set<Inventory>().Remove(data);
            dataContext.SaveChanges();

            return Ok();
        }
    }
}