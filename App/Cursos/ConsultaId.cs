using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Curso>
        {
            public int CursoId { get; set; }
            public class Manejador : IRequestHandler<CursoUnico, Curso>
            {
                private CursosOnlineContext context;
                public Manejador(CursosOnlineContext context)
                {
                    this.context = context;
                }

                public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
                {
                    var curso = await context.Curso.FindAsync(request.CursoId);
                    return curso;
                }
            }
        }
    }
}
