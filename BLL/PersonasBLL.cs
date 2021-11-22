using Microsoft.EntityFrameworkCore;
using ProyectoFinal_ContratacionEmpleados.DAL;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas Persona)
        {
            if (!Existe(Persona.PersonaId))
                return Insertar(Persona);
            else
                return Modificar(Persona);
        }

        private static bool Insertar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                

               /* foreach(var item in VacantesBLL.GetVacantes())
      SqliteException: SQLite Error 19: 'UNIQUE constraint failed: Empresas.EmpresaId'.          {
                    contexto.EntrMicrosoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while updating the entries. See the inner exception for details.'
y(item).State = EntityState.Modified;
                    if (item.VacanteId == Persona.VacanteId)
                        item.Disponible -= 1;
                }
               */
                
                contexto.Personas.Add(Persona);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var PersonaAnterior = contexto.Personas.Where(x => x.PersonaId == Persona.PersonaId)
                                           .Include(x => x.Detalle)
                                           .ThenInclude(x => x.Empresa)
                                           .Include(x => x.Genero)
                                           .Include(x => x.Vacante)
                                           .Include(x => x.Provincia)
                                           .AsNoTracking()
                                           .SingleOrDefault();

                PersonaAnterior.Vacante.Disponible += 1;
                contexto.Entry(PersonaAnterior.Vacante).State = EntityState.Modified;

                contexto.Database.ExecuteSqlRaw($"Delete From PersonasDetalle Where PersonaId = {Persona.PersonaId}");

                Persona.Vacante.Disponible -= 1;
                contexto.Entry(PersonaAnterior.Vacante).State = EntityState.Modified;

                contexto.Entry(Persona).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var Persona = PersonasBLL.Buscar(id);

                if (Persona != null)
                {

                    Persona.Vacante.Disponible += 1;
                    contexto.Entry(Persona.Vacante).State = EntityState.Modified;

                    contexto.Personas.Remove(Persona);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas Persona;

            try
            {
                Persona = contexto.Personas.Where(x => x.PersonaId == id)
                                           .Include(x => x.Detalle)
                                           .ThenInclude(x => x.Empresa)
                                           .Include(x => x.Genero)
                                           .Include(x => x.Vacante)
                                           .Include(x => x.Provincia)
                                           .AsNoTracking()
                                           .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Persona;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                contexto.Personas.Any(x => x.PersonaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> Criterio)
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Personas.Where(Criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
