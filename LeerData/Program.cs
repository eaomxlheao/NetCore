using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppVentaCursoContext())
            {
                /* var cursos=db.Curso.AsNoTracking(); //Arreglo IQueryable
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo);
                } */

                var cursos = db.Curso.Include(p => p.PrecioPromocion).AsNoTracking();
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso.Titulo + "---" + curso.PrecioPromocion.PrecioActual);
                }
            }
        }
    }
}
