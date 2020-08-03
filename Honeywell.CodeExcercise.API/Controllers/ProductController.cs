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
        private readonly IItemComponentRepository itemComponentRepository;
        public ProductController(IItemComponentRepository itemComponentRepository)
        {
            this.itemComponentRepository = itemComponentRepository;
        }

        /// <summary>
        /// This method get called on initial request from user
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("")]
        public async Task<ActionResult> GetItems()
        {
            try
            {
                return Ok(await itemComponentRepository.GetAllItem());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        /// <summary>
        /// This method will get called when user try to get item details based on item name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("view")]
        [HttpGet("view/{name:minlength(3)}")]
        public async Task<ActionResult<List<ItemViewModel>>> GetItemsByName(string name, [FromQuery] PagingParameterModel pagingParameterModel)
        {
            try
            {
                var result = await itemComponentRepository.GetItemsByName(name ?? "");

                if (result == null || result.Count == 0) return NotFound($"Record not found for input {name} ");

                int count = result.Count();
                int CurrentPage = pagingParameterModel.pageNumber;
                int PageSize = pagingParameterModel.pageSize;
                int TotalCount = count;
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                var items = result.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                var previousPage = CurrentPage > 1 ? "Yes" : "No";
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";
  
                var paginationMetadata = new
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage,
                    nextPage
                };

                return items;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        ///// <summary>
        ///// This method will add new item to existing item list
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                var createdItem = await itemComponentRepository.AddNewItem(item);

                return CreatedAtAction(nameof(GetItems), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating new item record");
            }
        }
    }
}
