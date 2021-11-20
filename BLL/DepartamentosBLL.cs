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
    public class DepartamentosBLL
    {
        public static bool Guardar(Departamentos departamento)
        {
            if (!Existe(departamento.DepartamentoId))
            {
                return Insertar(departamento);
            }
            else
            {
                return Modificar(departamento);
            }
        }

        private static bool Insertar(Departamentos departamento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Departamentos.Add(departamento);
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

        public static bool Modificar(Departamentos departamento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(departamento).State = EntityState.Modified;
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
                var departamento = contexto.Departamentos.Find(id);

                if (departamento != null)
                {
                    contexto.Departamentos.Remove(departamento);
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

        public static Departamentos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Departamentos departamento;

            try
            {
                departamento = contexto.Departamentos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return departamento;
        }

        public static List<Departamentos> GetList(Expression<Func<Departamentos, bool>> criterio)
        {
            List<Departamentos> lista = new List<Departamentos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Departamentos.Where(criterio).ToList();
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
                encontrado = contexto.Departamentos.Any(t => t.DepartamentoId == id);
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
                encontrado = contexto.Departamentos.Any(r => r.Nombre == nombre);
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

        public static List<Departamentos> GetDepartamentos()
        {
            List<Departamentos> lista = new List<Departamentos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Departamentos.ToList();
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
