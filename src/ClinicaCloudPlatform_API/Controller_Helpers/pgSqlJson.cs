using System.Collections.Generic;
using System.Linq;
using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.Models;
using Microsoft.EntityFrameworkCore;
//TODO: move to DAL
namespace ClinicaCloudPlatform.API.Controller_Helpers
{
    public class pgSqlJson
    {
        private ArsMachinaLIMSContext _context;
        public pgSqlJson(ArsMachinaLIMSContext Context)
        {
            _context = Context;
        }

        public List<Patient> GetPatientsByOrganization(string OrgNameKey)
        {
            return _context.Patients.ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }

        public List<Client> GetClientsByOrganization(string OrgNameKey)
        {
            return _context.Clients.Include(c=>c.Facilities).ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }

        public List<Doctor> GetDoctorsByOrganization(string OrgNameKey)
        {
            return _context.Doctors.ToList(); //need to use Microsoft.EntityFrameworkCore.Relational .FromSql extension, so pgsql can query json to filter patients by org
        }
    }
}
