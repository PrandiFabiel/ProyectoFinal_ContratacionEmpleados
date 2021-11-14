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
    public class VacantesBLL
    {
        public static bool Guardar(Vacantes vacante)
        {
            if (!Existe(vacante.VacanteId))
                return Insertar(vacante);
            else
                return Modificar(vacante);
        }

        public static bool Insertar(Vacantes vacante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Vacantes.Add(vacante);
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

        public static bool Modificar(Vacantes vacante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vacante).State = EntityState.Modified;
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
                var vacante = contexto.Vacantes.Find(id);

                if (vacante != null)
                {
                    contexto.Vacantes.Remove(vacante);
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
                encontrado = contexto.Vacantes.Any(e => e.VacanteId == id);
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

        public static Vacantes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vacantes vacante;
            try
            {
                vacante = contexto.Vacantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return vacante;
        }

        public static List<Vacantes> GetList(Expression<Func<Vacantes, bool>> criterio)
        {
            List<Vacantes> lista = new List<Vacantes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Vacantes.Where(criterio).ToList();
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
