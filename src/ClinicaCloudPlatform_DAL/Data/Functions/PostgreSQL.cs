using System.Collections.Generic;
using System.Linq;
using ClinicaCloudPlatform.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicaCloudPlatform.DAL.Data.Functions
{
    public class PostgreSQL
    {
        private ArsMachinaLIMSContext _context;
        public PostgreSQL(ArsMachinaLIMSContext Context)
        {
            _context = Context;
        }

        public T SqlQuery<T>(string SQL)
            where T : class, IModel
        {
            return _context.Set<T>().FromSql<T>(SQL).FirstOrDefault();
        }

        public List<Patient> GetPatientsByOrganization(string OrgNameKey)
        {
            return _context.Patients.ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }

        public List<Client> GetClientsByOrganization(string OrgNameKey)
        {
            return _context.Clients.Include(c => c.Facilities).ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }

        public List<Doctor> GetDoctorsByOrganization(string OrgNameKey)
        {
            return _context.Doctors.ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }
    }
}
