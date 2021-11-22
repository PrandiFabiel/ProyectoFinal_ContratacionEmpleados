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
    public class ProvinciasBLL
    {
        public static bool Guardar(Provincias Provincia)
        {
            if (!Existe(Provincia.ProvinciaId))
                return Insertar(Provincia);
            else
                return Modificar(Provincia);
        }

        private static bool Insertar(Provincias Provincia)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Provincia.UsuarioId = Utilidades.User.UsuarioId;
                contexto.Provincias.Add(Provincia);
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

        private static bool Modificar(Provincias Provincia)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Provincia).State = EntityState.Modified;
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
                var provincia = ProvinciasBLL.Buscar(id);

                if (provincia != null)
                {
                    contexto.Provincias.Remove(provincia);
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

        public static Provincias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Provincias provincia;

            try
            {
                provincia = contexto.Provincias.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return provincia;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                contexto.Provincias.Any(x => x.ProvinciaId == id);
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

        public static List<Provincias> GetList(Expression<Func<Provincias, bool>> Criterio)
        {
            List<Provincias> lista = new List<Provincias>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Provincias.Where(Criterio).ToList();
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

        public static List<Provincias> GetProvincias()
        {
            Contexto contexto = new Contexto();
            List<Provincias> lista = new List<Provincias>();

            try
            {
                lista = contexto.Provincias.ToList();
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
