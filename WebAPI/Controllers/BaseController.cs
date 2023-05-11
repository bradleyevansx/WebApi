using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

    public class BaseController<T> : ControllerBase where T : Entity
    {
        public IRepository<T> _repositoryConnection { get; }

        public BaseController(IRepository<T> repositoryConnection)
        {
            _repositoryConnection = repositoryConnection;
        }

        [HttpGet("{id}"), Authorize]
        public Task<T> GetAsync(string id)
        {
            return _repositoryConnection.Get(id);
        }
        
        [HttpGet, Authorize]
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repositoryConnection.GetAll();
        }

        [HttpPost, Authorize]
        public IActionResult CreateAsync([FromBody] T entity)
        {
            var result = _repositoryConnection.Add(entity);
            if (result is not null) return Ok("Entity Created");
            else return BadRequest("Error In Creating the Entity");
        }
        
        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteAsync(string id)
        {
            var result = _repositoryConnection.Delete(id);
            if (result is not null) return Ok("Entity Deleted");
            else return BadRequest("Error In Deleting the Entity");
        }
        
        [HttpPut, Authorize]
        public IActionResult UpdateAsync([FromBody] T entity)
        {
            var result = _repositoryConnection.Update(entity);;
            if (result is not null) return Ok("Entity Updated");
            else return BadRequest("Error In Updating the Entity");
        }
    }
