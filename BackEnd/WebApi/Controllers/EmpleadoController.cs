using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DomainModel.Entitles.Models;
using DomainModel.Services.EmpleadoService;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _customerService;

        public EmpleadoController(IEmpleadoService logger)
        {
            _customerService = logger;
        }

        // GET: EmpleadoController
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

        // GET: EmpleadoController/Details/5
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

        // GET: EmpleadoController/Create
        [HttpPost]
        public ActionResult Create([FromBody] Empleado customer)
        {
            _customerService.Add(customer);
            return Ok("Ingresado");
        }

        // GET: EmpleadoController/Edit/5
        [HttpPut]
        public ActionResult Edit([FromBody] Empleado customer)
        {
            _customerService.Update(customer);
            return Ok("Actualizado");
        }

        // GET: EmpleadoController/Delete/5
        [HttpDelete]
        public ActionResult Delete(Empleado customer)
        {
            _customerService.Remove(customer);
            return Ok("Eliminado");
        }


    }
}