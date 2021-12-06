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
                vacante.UsuarioId = Utilidades.User.UsuarioId;
                foreach (var detalle in vacante.VacantesDetalle)
                {
                    detalle.Habilidad.VecesAsignada += 1;
                    contexto.Entry(detalle.Habilidad).State = EntityState.Modified;
                }
                
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
                var vacanteAnterior = contexto.Vacantes
                                               .Where(x => x.VacanteId == vacante.VacanteId)
                                               .Include(x => x.VacantesDetalle)
                                               .ThenInclude(x => x.Habilidad)
                                               .AsNoTracking()
                                               .SingleOrDefault();

                foreach (var detalle in vacanteAnterior.VacantesDetalle)
                {
                    var habilidad = contexto.Habilidades.Find(detalle.Habilidad.HabilidadId);
                    habilidad.VecesAsignada -= 1;
                    detalle.Habilidad = habilidad;
                    contexto.Entry(detalle.Habilidad).State = EntityState.Modified;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM VacantesDetalle Where VacanteId = {vacante.VacanteId}");

                foreach (var item in vacante.VacantesDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    var habilidad = contexto.Habilidades.Find(item.Habilidad.HabilidadId);
                    habilidad.VecesAsignada += 1;
                    item.Habilidad = habilidad;
                    contexto.Entry(item.Habilidad).State = EntityState.Modified;
                }

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
                var vacante = VacantesBLL.Buscar(id);

                if (vacante != null)
                {
                    foreach (var detalle in vacante.VacantesDetalle)
                    {
                        detalle.Habilidad.VecesAsignada -= 1;
                        contexto.Entry(detalle.Habilidad).State = EntityState.Modified;
                    }

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
                vacante = contexto.Vacantes.Where(x => x.VacanteId == id)
                                             .Include(x => x.VacantesDetalle)
                                             .ThenInclude(x => x.Habilidad)
                                             .AsNoTracking()
                                             .SingleOrDefault();
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

        public static List<VacantesDetalle> GetListDetalle(int id)
        {
            List<VacantesDetalle> lista = new List<VacantesDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                var vacante = VacantesBLL.Buscar(id);
                if (vacante != null)
                {
                    lista = vacante.VacantesDetalle;
                    //var lista2 = lista.Where(criterio);
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
            return lista;
        }

        public static List<Vacantes> GetVacantes()
        {
            Contexto contexto = new Contexto();
            List<Vacantes> lista = new List<Vacantes>();

            try
            {
                lista = contexto.Vacantes.ToList();
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
