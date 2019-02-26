using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace MKT.DataAccess.ServiceObjects
{
    public class SO_Gerente
    {
        public IList GetAllGerente()
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    var ListaGerentes = (from a in Conexion.Gerente
                                         select a).ToList();
                    return ListaGerentes;
                }
            }
            catch (Exception er)
            {

                throw;
            }
        }

        public IList GetGerente(string codigoNomina)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    var lista = (from a in Conexion.Gerente
                                 where a.CodigoNomina == codigoNomina
                                 select a).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetGerente(int idGerente)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    var lista = (from a in Conexion.Gerente
                                 where a.Id == idGerente
                                 select a).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Insert(string codigoNomina, string nombre, string entidad, bool activo, DateTime fechaInicio, DateTime fechaTermino, string cargo)
        {
            
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    Gerente gerente = new Gerente();
                    
                    gerente.CodigoNomina = codigoNomina;
                    gerente.Nombre = nombre;
                    gerente.Cargo = cargo;
                    gerente.Entidad = entidad;
                    gerente.Activo = activo;
                    gerente.FechaInicio = fechaInicio;

                    if (fechaTermino != DateTime.MinValue)
                    {
                        gerente.FechaTermino = fechaTermino;
                    }
                    
                    Conexion.Gerente.Add(gerente);

                    Conexion.SaveChanges();

                    return gerente.Id;
                }
            }
            catch (System.Exception er)
            {
                return 0;
            }
        }

        public int Update(int id, string codigoNomina, string nombre, string entidad, bool activo, DateTime fechaInicio, DateTime fechaTermino, string cargo)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    Gerente gerente = Conexion.Gerente.Where(x => x.Id == id).FirstOrDefault();

                    gerente.CodigoNomina = codigoNomina;
                    gerente.Nombre = nombre;
                    gerente.Cargo = cargo;
                    gerente.Entidad = entidad;
                    gerente.Activo = activo;
                    gerente.FechaInicio = fechaInicio;
                    gerente.FechaTermino = fechaTermino;

                    Conexion.Entry(gerente).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                using (var Conexion = new EntitiesMKT())
                {
                    Gerente gerente = Conexion.Gerente.Where(x => x.Id == id).FirstOrDefault();

                    Conexion.Entry(gerente).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }
    }
}