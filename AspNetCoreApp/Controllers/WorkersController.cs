using AspNetCoreApp.Loggers;
using AspNetCoreApp.Models;
using AspNetCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Worker")]

    public class WorkersController : Controller
    {
        IJobService _service;
        ILoggerFactory _loggerFactory;
        ILogger _logger;
        public WorkersController(IJobService service)
        {
            _loggerFactory = new LoggerFactory().AddFile(Path.Combine(Directory.GetCurrentDirectory(), "workerLogs.txt"));
            _logger = _loggerFactory.CreateLogger("FileLogger");
            _service = service;
        }

        //GET api/Worker 
        [HttpGet]
        public async Task<IEnumerable<Worker>> Get()
        {
            _logger.LogInformation($"Get items {DateTime.Now.ToString()}");

            return await _service.GetAllAsync();
        }

        //GET api/Worker/Id 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.LogInformation($"Get items {DateTime.Now.ToString()}");
            
            var response = _service.GetByIdAsync(id);
            if (response != null)
            {
                _logger.LogWarning($"{DateTime.Now.ToString()} sorry this element doesn`t exist");
            }
            return Ok(response);
        }

        //Post api/Worker 
        [HttpPost]
        public async Task<IActionResult> PostWorker([FromBody] Worker worker)
        {
            await _service.AddAsync(worker);
            _logger.LogInformation($"Add item: Id={worker.Id}, {DateTime.Now.ToString()}");
            return Ok(worker);
        }

        // DELETE api/Worker/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker([FromRoute] int id)
        {
            var worker = await _service.GetByIdAsync(id);
            if (worker == null)
            {
                _logger.LogInformation($"{DateTime.Now.ToString()} there are no worker with this id");
                return NotFound();
            }

            await _service.DeleteAsync(worker.Id);

            _logger.LogInformation($"Worker with {worker.Id} {worker.FirstName} was removed {DateTime.Now.ToString()}");
            return Ok(worker);
        }

    }
}