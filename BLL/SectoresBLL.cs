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
    public class SectoresBLL
    {
        public static bool Guardar(Sectores sector)
        {
            if (!Existe(sector.SectorId))
            {
                return Insertar(sector);
            }
            else
            {
                return Modificar(sector);
            }
        }

        private static bool Insertar(Sectores sector)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                sector.UsuarioId = Utilidades.User.UsuarioId;
                contexto.Sectores.Add(sector);
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

        public static bool Modificar(Sectores sector)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(sector).State = EntityState.Modified;
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
                var sector = contexto.Sectores.Find(id);

                if (sector != null)
                {
                    contexto.Sectores.Remove(sector);
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

        public static Sectores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Sectores sector;

            try
            {
                sector = contexto.Sectores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return sector;
        }

        public static List<Sectores> GetList(Expression<Func<Sectores, bool>> criterio)
        {
            List<Sectores> lista = new List<Sectores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Sectores.Where(criterio).ToList();
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
                encontrado = contexto.Sectores.Any(t => t.SectorId == id);
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

        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Sectores.Any(r => r.Nombre == nombre);
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

        public static List<Sectores> GetSectores()
        {
            List<Sectores> lista = new List<Sectores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Sectores.ToList();
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
