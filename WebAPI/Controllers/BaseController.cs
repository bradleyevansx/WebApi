using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;
using WebAPITest.Repository;

namespace WebAPITest.Controllers;

    public class BaseController<T> : ControllerBase where T : Entity
    {
        protected IRepository<T> RepositoryConnection;

        [HttpGet("{id}")]
        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
            // return RepositoryConnection.Get(entity.id, entity.partitionKey);
        }
        
        [HttpGet]
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return RepositoryConnection.GetAll();
        }

        [HttpPost]
        public IActionResult CreateAsync([FromBody] T entity)
        {
            var result = RepositoryConnection.Add(entity);
            if (result is not null) return Ok("Entity Created");
            else return BadRequest("Error in Creating the Entity");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(string id)
        {
            var result = RepositoryConnection.Delete(id);
            if (result is not null) return Ok("Entity Deleted");
            else return BadRequest("Error in Deleting the Entity");
        }
        
        [HttpPut]
        public Task<ItemResponse<T>> UpdateAsync([FromBody] T entity)
        {
            return RepositoryConnection.Update(entity);
        }
    }
