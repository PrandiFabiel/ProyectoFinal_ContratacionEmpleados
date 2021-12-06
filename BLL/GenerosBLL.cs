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
    public class GenerosBLL
    {
        public static bool Guardar(Generos Genero)
        {
            if (!Existe(Genero.GeneroId))
                return Insertar(Genero);
            else
                return Modificar(Genero);
        }

        private static bool Insertar(Generos Genero)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Genero.UsuarioId = Utilidades.User.UsuarioId;
                contexto.Generos.Add(Genero);
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

        private static bool Modificar(Generos Genero)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Genero).State = EntityState.Modified;
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
                var genero = GenerosBLL.Buscar(id);

                if(genero != null)
                {
                    contexto.Generos.Remove(genero);
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

        public static Generos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Generos genero;

            try
            {
                genero = contexto.Generos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return genero;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
               encontrado = contexto.Generos.Any(x => x.GeneroId == id);
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

        public static List<Generos> GetList(Expression<Func<Generos, bool>> Criterio)
        {
            List<Generos> lista = new List<Generos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Generos.Where(Criterio).ToList();
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

        public static List<Generos> GetGeneros()
        {
            Contexto contexto = new Contexto();
            List<Generos> lista = new List<Generos>();

            try
            {
                lista = contexto.Generos.ToList();
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

        public static bool ExisteNombre(string datos)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Generos.Any(x => x.Descripcion == datos);
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
    }
}
