using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;
using WebAPITest.Repository;

namespace WebAPITest.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        protected IRepository<T> RepositoryConnection;

        [HttpGet(nameof(Get))]
        public Task<T> Get([FromQuery] Entity entity)
        {
            return RepositoryConnection.Get(entity.id, entity.partitionKey);
        }
        
        [HttpGet(nameof(GetAll))]
        public Task<IEnumerable<T>> GetAll()
        {
            return RepositoryConnection.GetAll();
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create([FromBody] T entity)
        {
            var result = RepositoryConnection.Add(entity);
            if (result is not null) return Ok("Entity Created");
            else return BadRequest("Error in Creating the Entity");
        }
        
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(string id, string partitionKey)
        {
            var result = RepositoryConnection.Delete(id, partitionKey);
            if (result is not null) return Ok("Entity Deleted");
            else return BadRequest("Error in Deleting the Entity");
        }
        
        [HttpPut(nameof(Update))]
        public Task<ItemResponse<T>> Update(T entity, string partitionKey)
        {
            return RepositoryConnection.Update(entity, partitionKey);
        }
    }
