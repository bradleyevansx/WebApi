using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Controllers;

    public class BaseController<T> : ControllerBase where T : Entity
    {
        public IRepository<T> RepositoryConnection { get; }

        public BaseController(IRepository<T> repositoryConnection)
        {
            RepositoryConnection = repositoryConnection;
        }

        [HttpGet("{id}"), Authorize]
        public Task<T> GetAsync(string id)
        {
            return RepositoryConnection.Get(id);
        }
        
        [HttpGet, Authorize]
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return RepositoryConnection.GetAll();
        }

        [HttpPost, Authorize]
        public IActionResult CreateAsync([FromBody] T entity)
        {
            var result = RepositoryConnection.Add(entity);
            if (result is not null) return Ok("Entity Created");
            else return BadRequest("Error In Creating the Entity");
        }
        
        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteAsync(string id)
        {
            var result = RepositoryConnection.Delete(id);
            if (result is not null) return Ok("Entity Deleted");
            else return BadRequest("Error In Deleting the Entity");
        }
        
        [HttpPut, Authorize]
        public IActionResult UpdateAsync([FromBody] T entity)
        {
            var result = RepositoryConnection.Update(entity);;
            if (result is not null) return Ok("Entity Updated");
            else return BadRequest("Error In Updating the Entity");
        }
    }
