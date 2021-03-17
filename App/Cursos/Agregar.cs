using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Agregar
    {
        public class Ejecuta : IRequest
        {
            [Required(ErrorMessage = "Por favor ingrese el título")]
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public System.DateTime FechaPublicacion { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            CursosOnlineContext context;
            public Manejador(CursosOnlineContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = new Curso() { Descripcion = request.Descripcion, Titulo = request.Titulo, FechaPublicacion = request.FechaPublicacion };
                this.context.Curso.Add(curso);
                int registros = await this.context.SaveChangesAsync();
                if (registros == 1)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el curso");
            }
        }
    }
}
