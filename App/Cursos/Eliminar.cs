using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public int id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            CursosOnlineContext context;
            public Manejador(CursosOnlineContext _contex)
            {
                this.context = _contex;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = await this.context.Curso.FindAsync(request.id);
                if (curso == null)
                {
                    throw new Exception("No existe el curso");
                }
                this.context.Remove(curso);
                var registros = await this.context.SaveChangesAsync();

                if (registros > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
