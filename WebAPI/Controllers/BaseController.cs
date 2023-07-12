using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers;

    public class BaseController<T> : ControllerBase where T : Entity
    {
        public IRepository<T> _repositoryConnection { get; }

        public BaseController(IRepository<T> repositoryConnection)
        {
            _repositoryConnection = repositoryConnection;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var item = await _repositoryConnection.Get(id);

            if (item is null)
            {
                return NotFound();
            }
            
            return Ok(item);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var item = await _repositoryConnection.GetAll();

            if (item.Count() is 0)
            {
                return NotFound();
            }
            
            return Ok(item);
        }
            
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] T entity)
        {
            var result = await _repositoryConnection.Add(entity);
            if (result.Resource is not null) return Ok("Entity Created");
            else return BadRequest("Error In Creating the Entity");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _repositoryConnection.Delete(id);
            if (result.StatusCode is HttpStatusCode.OK) return Ok("Entity Deleted");
            else return BadRequest("Error In Deleting the Entity");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] T entity)
        {
            var result = await _repositoryConnection.Update(entity);;
            if (result.StatusCode is HttpStatusCode.OK) return Ok(result.Resource);
            else return BadRequest("Error In Updating the Entity");
        }
    }
