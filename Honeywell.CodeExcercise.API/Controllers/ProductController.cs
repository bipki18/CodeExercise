using Honeywell.CodeExcercise.API.Models;
using Honeywell.CodeExercise.Component.ItemComponent;
using Honeywell.CodeExercise.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IItemRepository itemRepository; 

        public ProductController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }


 
        public async Task<ActionResult> GetItems()
        {
            try
            {
                return Ok(await itemRepository.GetItem());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<List<ItemViewModel>>> GetItemsByName(string name)
        {
            try
            {
                var result = await itemRepository.GetItemsByName(name);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                var createdItem = await itemRepository.AddItem(item);

                return CreatedAtAction(nameof(createdItem), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new item record");
            }
        }

    }
}
