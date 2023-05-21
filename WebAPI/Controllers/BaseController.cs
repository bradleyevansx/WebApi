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
        public Task<T> GetAsync(string id)
        {
            return _repositoryConnection.Get(id);
        }
        
        [HttpGet]
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repositoryConnection.GetAll();
        }

        [HttpPost]
        public IActionResult CreateAsync([FromBody] T entity)
        {
            var result = _repositoryConnection.Add(entity);
            if (result is not null) return Ok("Entity Created");
            else return BadRequest("Error In Creating the Entity");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(string id)
        {
            var result = _repositoryConnection.Delete(id);
            if (result is not null) return Ok("Entity Deleted");
            else return BadRequest("Error In Deleting the Entity");
        }
        
        [HttpPut]
        public IActionResult UpdateAsync([FromBody] T entity)
        {
            var result = _repositoryConnection.Update(entity);;
            if (result is not null) return Ok("Entity Updated");
            else return BadRequest("Error In Updating the Entity");
        }
    }
