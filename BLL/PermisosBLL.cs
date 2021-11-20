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
    public class PermisosBLL
    {
        public static bool Guardar(Permisos permiso)
        {
            if (!Existe(permiso.PermisoId))
            {
                return Insertar(permiso);
            }
            else
            {
                return Modificar(permiso);
            }
        }

        private static bool Insertar(Permisos permiso)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Permisos.Add(permiso);
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

        public static bool Modificar(Permisos permiso)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(permiso).State = EntityState.Modified;
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
                var permiso = contexto.Permisos.Find(id);

                if (permiso != null)
                {
                    contexto.Permisos.Remove(permiso);
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

        public static Permisos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Permisos permiso;

            try
            {
                permiso = contexto.Permisos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return permiso;
        }

        public static List<Permisos> GetList(Expression<Func<Permisos, bool>> criterio)
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Permisos.Where(criterio).ToList();
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
                encontrado = contexto.Permisos.Any(t => t.PermisoId == id);
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
                encontrado = contexto.Permisos.Any(r => r.Descripcion == descripcion);
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

        public static List<Permisos> GetPermisos()
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Permisos.ToList();
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

        public static string GetDescripcion(int permisoId)
        {
            List<Permisos> lista = new();

            lista = PermisosBLL.GetPermisos();
            string descri = "";
            foreach (var item in lista)
            {
                if (item.PermisoId == permisoId)
                    descri = item.Descripcion;
            }

            return descri;
        }

        public static int GetVecesAsignado(int permisoId)
        {
            List<Permisos> lista = new();

            lista = PermisosBLL.GetPermisos();
            int valor = 0;
            foreach (var item in lista)
            {
                if (item.PermisoId == permisoId)
                    valor = item.VecesAsignado;
            }

            return valor;
        }
    }
}
