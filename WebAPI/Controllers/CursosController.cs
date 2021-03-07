using Aplicacion.Cursos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //http://localhost/api/cursos
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : Controller
    {
        private readonly IMediator mediator;
        public CursosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await mediator.Send(new Consulta.ListaCursos());
        }

        //http://localhost/api/cursos/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> Detalle(int id)
        {
            var curso = await mediator.Send(new ConsultaId.CursoUnico { CursoId = id });
            return curso;
        }
    }
}
