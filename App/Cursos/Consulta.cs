using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<Curso>> { }

        /// <summary>
        /// 
        /// </summary>
        public class Manejador : IRequestHandler<ListaCursos, List<Curso>>
        {
            private CursosOnlineContext context;

            public Manejador(CursosOnlineContext context)
            {
                this.context = context;
            }

            /// <summary>
            /// Manejador que obtiene la lista de cursos
            /// </summary>
            /// <param name="request">El tipo de Datoa</param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<List<Curso>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var cursos = await context.Curso.ToListAsync();
                return cursos;
            }
        }
    }
}
