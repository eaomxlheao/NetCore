using FluentValidation;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public int CursoId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public System.DateTime? FechaPublicacion { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private CursosOnlineContext contex;
            public Manejador(CursosOnlineContext _context)
            {
                this.contex = _context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = await this.contex.Curso.FindAsync(request.CursoId);
                if (curso == null)
                {
                    throw new Exception("El curso no existe");
                }
                curso.Descripcion = request.Descripcion ?? curso.Descripcion;
                curso.Titulo = request.Titulo ?? curso.Titulo;
                curso.FechaPublicacion = request.FechaPublicacion ?? curso.FechaPublicacion;

                int registros = await contex.SaveChangesAsync();
                if (registros > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("No se actualizó ningun curso");
                }
            }
        }
    }
}
