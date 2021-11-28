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
        public static bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        private static bool Insertar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var vacante = VacantesBLL.GetVacantes();

                foreach (var item in vacante)
                {
                    if (item.VacanteId == persona.VacanteId)
                    {
                        item.Disponible -= 1;
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

                contexto.Personas.Add(persona);

                foreach (var item in persona.Detalle)
                {
                    contexto.Entry(item.Empresa).State = EntityState.Unchanged;
                }

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

        private static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var vacante = VacantesBLL.GetVacantes();

                foreach(var item in vacante)
                {
                    if(item.VacanteId == persona.VacanteId)
                    {
                        item.Disponible += 1;
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM PersonasDetalle Where PersonaId = {persona.PersonaId}");

                foreach (var item in vacante)
                {
                    if (item.VacanteId == persona.VacanteId)
                    {
                        item.Disponible -= 1;
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

                foreach (var item in persona.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(persona).State = EntityState.Modified;
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

        public static Personas Buscar(int id)
        {
            Personas Persona;
            Contexto contexto = new Contexto();

            try
            {
                Persona = contexto.Personas.Where(x => x.PersonaId == id)
                                           .Include(x => x.Detalle)
                                           .ThenInclude(x => x.Empresa)
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var persona = PersonasBLL.Buscar(id);

                if (persona != null)
                {
                    var vacante = VacantesBLL.GetVacantes();

                    foreach (var item in vacante)
                    {
                        if (item.VacanteId == persona.VacanteId)
                        {
                            item.Disponible += 1;
                            contexto.Entry(item).State = EntityState.Modified;
                        }
                    }

                    contexto.Personas.Remove(persona);
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Personas.Any(x => x.PersonaId == id);
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

        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Personas.Where(criterio).ToList();
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
