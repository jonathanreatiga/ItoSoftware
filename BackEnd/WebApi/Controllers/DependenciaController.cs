using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DomainModel.Entitles.Models;
using DomainModel.Services.DependenciaService;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class DependenciaController : ControllerBase
    {
        private readonly IDependenciaService _customerService;

        public DependenciaController(IDependenciaService logger)
        {
            _customerService = logger;
        }

        
        // GET: DependenciaController
        [HttpGet]
        public ActionResult Index()
        {
            var result = _customerService.GetAll();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        // GET: DependenciaController/Details/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var result = _customerService.GetById(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("Error");
        }

        // GET: DependenciaController/Create
        [HttpPost]
        public ActionResult Create([FromBody] Dependencia customer)
        {
            _customerService.Add(customer);
            return Ok("Ingresado");
        }

        // GET: DependenciaController/Edit/5
        [HttpPut]
        public ActionResult Edit([FromBody] Dependencia customer)
        {
            _customerService.Update(customer);
            return Ok("Actualizado");
        }

        // GET: DependenciaController/Delete/5
        [HttpDelete]
        public ActionResult Delete(Dependencia customer)
        {
            _customerService.Remove(customer);
            return Ok("Eliminado");
        }

    }
}