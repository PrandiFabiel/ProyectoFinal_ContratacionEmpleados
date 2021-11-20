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
    public class EmpresasBLL
    {
        public static bool Guardar(Empresas Empresa)
        {
            if (!Existe(Empresa.EmpresaId))
                return Insertar(Empresa);
            else
                return Modificar(Empresa);
        }

        private static bool Insertar(Empresas Empresa)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Empresas.Add(Empresa);
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

        private static bool Modificar(Empresas Empresa)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Empresa).State = EntityState.Modified;
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
                var Empresa = EmpresasBLL.Buscar(id);

                if (Empresa != null)
                {
                    contexto.Empresas.Remove(Empresa);
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

        public static Empresas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Empresas Empresa;

            try
            {
                Empresa = contexto.Empresas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Empresa;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                contexto.Empresas.Any(x => x.EmpresaId == id);
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

        public static List<Empresas> GetList(Expression<Func<Empresas, bool>> Criterio)
        {
            List<Empresas> lista = new List<Empresas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Empresas.Where(Criterio).ToList();
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

        public static List<Empresas> GetEmpresas()
        {
            Contexto contexto = new Contexto();
            List<Empresas> lista = new List<Empresas>();

            try
            {
                lista = contexto.Empresas.ToList();
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

