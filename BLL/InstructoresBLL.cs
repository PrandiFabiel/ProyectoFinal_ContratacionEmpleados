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
    public class InstructoresBLL
    {
        public static bool Guardar(Instructores Instructor)
        {
            if (!Existe(Instructor.InstructorId))
                return Insertar(Instructor);
            else
                return Modificar(Instructor);
        }

        public static bool Insertar(Instructores Instructor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                contexto.Instructores.Add(Instructor); 
                paso = (contexto.SaveChanges() > 0);
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

        public static bool Modificar(Instructores Instructor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Instructor).State = EntityState.Modified;
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
                var instructor = contexto.Instructores.Find(id);

                if (instructor != null)
                {
                    contexto.Instructores.Remove(instructor);
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
                encontrado = contexto.Instructores.Any(e => e.InstructorId == id);
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

        public static Instructores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Instructores instructor;
            try
            {
                instructor = contexto.Instructores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return instructor;
        }

        public static List<Instructores> GetList(Expression<Func<Instructores, bool>> Criterio)
        {
            List<Instructores> lista = new List<Instructores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Instructores.Where(Criterio).ToList();
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
