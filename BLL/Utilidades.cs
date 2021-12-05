using ProyectoFinal_ContratacionEmpleados.DAL;
using ProyectoFinal_ContratacionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ContratacionEmpleados.BLL
{
    public class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;

            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static Usuarios User = new Usuarios();

        public static List<Ciudades> getCiudades(int id)
        {
            List<Ciudades> lista = new List<Ciudades>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ciudades.Where(x => x.ProvinciaId == id).ToList();
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

        public static List<Sectores> getSectores(int id)
        {
            List<Sectores> lista = new List<Sectores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Sectores.Where(x => x.CiudadId == id).ToList();
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
