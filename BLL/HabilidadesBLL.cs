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
    public class HabilidadesBLL
    {
        public static bool Guardar(Habilidades habilidad)
        {
            if (!Existe(habilidad.HabilidadId))
            {
                return Insertar(habilidad);
            }
            else
            {
                return Modificar(habilidad);
            }
        }

        private static bool Insertar(Habilidades habilidad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                habilidad.UsuarioId = Utilidades.User.UsuarioId;
                contexto.Habilidades.Add(habilidad);
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

        public static bool Modificar(Habilidades habilidad)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(habilidad).State = EntityState.Modified;
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
                var habilidad = contexto.Habilidades.Find(id);

                if (habilidad != null)
                {
                    contexto.Habilidades.Remove(habilidad);
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

        public static Habilidades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Habilidades habilidad;

            try
            {
                habilidad = contexto.Habilidades.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return habilidad;
        }

        public static List<Habilidades> GetList(Expression<Func<Habilidades, bool>> criterio)
        {
            List<Habilidades> lista = new List<Habilidades>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Habilidades.Where(criterio).ToList();
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Habilidades.Any(t => t.HabilidadId == id);
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

        public static bool ExisteDescripcion(string descripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Habilidades.Any(r => r.Descripcion == descripcion);
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

        public static List<Habilidades> GetHabilidades()
        {
            List<Habilidades> lista = new List<Habilidades>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Habilidades.ToList();
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
