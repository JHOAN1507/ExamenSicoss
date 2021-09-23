using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class HelperData
    {
        protected CentroMedicoEntities MyContext;
        public HelperData()
        {
            MyContext = new CentroMedicoEntities();

        }
        public List<Cita> GetCitas()
        {
            //MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Cita.ToList();
        }
        public Cita GetCita(int id)
        {
            //MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Cita.Where(D=>D.IdCita == id ).FirstOrDefault();
        }
        public void InsertCita(Cita cita)
        {
            MyContext.Set<Cita>().Add(cita);
            MyContext.SaveChanges();

        }
        public void UpdateCitas(Cita cita)
        {
            MyContext.Entry<Cita>(cita).State = System.Data.Entity.EntityState.Modified;
            MyContext.SaveChanges();
        }
        public void DeletedCita(Cita cita)
        {
            //MyContext.Entry<Cita>(cita).State = System.Data.Entity.EntityState.Deleted;

            MyContext.SP_EliminarCita(cita.IdCita);
            //MyContext.SaveChanges();
        }

        public List<Medico> GetMedico()
        {
            //MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Medico.ToList();
        }
        public List<Paciente> GetPaciente()
        {
            //MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Paciente.ToList();
        }
        public List<Especialidad> GetEspecialidad()
        {
            //MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Especialidad.ToList();
        }

        public Cita GetCitaLazy(int id)
        {
            MyContext.Configuration.LazyLoadingEnabled = false;
            return MyContext.Cita.Where(D => D.IdCita == id).FirstOrDefault();
        }
        public void InsertPaciente(Paciente paciente)
        {
            MyContext.Set<Paciente>().Add(paciente);
            MyContext.SaveChanges();

        }
        public void InsertMedico(Medico medico)
        {
            MyContext.Set<Medico>().Add(medico);
            MyContext.SaveChanges();

        }
        public void InsertEspecialidades(Especialidad especialidad)
        {
            MyContext.Set<Especialidad>().Add(especialidad);
            MyContext.SaveChanges();

        }
    }
}
