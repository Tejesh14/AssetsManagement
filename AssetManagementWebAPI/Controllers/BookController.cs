using AssetManagementWebAPI.Business_Logic_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Presentation_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            try
            {
                return Ok(await _bookService.Display());
            }
            catch
            {
                return NotFound("Data not found"); 
            }
        }

        [Route("{id}")]
        [HttpPatch]
        public async Task<ActionResult<Book>> UnAssign(int id)
        {
            try
            {
                return Ok(await _bookService.UnAssign(id));
            }
            catch
            {
                return NotFound("Data not found");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            try
            {
                return Ok(await _bookService.AddBook(book));
            }
            catch
            {
                return NotFound("Data not created");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            try
            {
                return Ok(await _bookService.Delete(id));
            }
            catch
            {
                return BadRequest("Not deleted");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Book>> Update(int id, Book book)
        {
            try
            {
                return Ok(await _bookService.Update(id, book));
            }
            catch
            {
                return BadRequest("Not Updated");
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Book>> Assign(int id, string userName)
        {
            try
            {
                var data = await _bookService.Assign(id, userName);
                if (data.AssignTo == userName)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Asset already assigned");
                }
            }
            catch
            {
                return BadRequest("Not Updated");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Book>> Search(int id)
        {
            try
            {
                return Ok(await _bookService.Search(id));
            }
            catch
            {
                return NotFound("Not found");
            }
        }
    }
}
