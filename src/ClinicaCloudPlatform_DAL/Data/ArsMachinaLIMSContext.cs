using Microsoft.EntityFrameworkCore;
using ClinicaCloudPlatform.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaCloudPlatform.DAL.Data
{
    public class ArsMachinaLIMSContext : DbContext
    {
        bool injectionDone = false;

        public ArsMachinaLIMSContext()
        {
        }

        public ArsMachinaLIMSContext(DbContextOptions<ArsMachinaLIMSContext> options)
        : base(options)
        {
            injectionDone = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!injectionDone)
                optionsBuilder.UseNpgsql("User ID=amlims;Password=P@ssw0rd;Host=arslinux1.westus.cloudapp.azure.com;Port=5432;Database=amlims_dev;Pooling=true;");
        }

        //public DbSet<Accession> Accessions { get; set; }
        //public DbSet<Batch> Batches { get; set; }
        //public DbSet<BatchType> BatchTypes { get; set; }
        //public DbSet<Case> Cases { get; set; }
        //public DbSet<CaseType> CaseTypes { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Dashboard> Dashboards { get; set; }
        //public DbSet<DashboardSection> DashboardSection { get; set; }
        //public DbSet<DashboardComponent> DashboardComponentss { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Facility> Facilities { get; set; }
        //public DbSet<Lab> Labs { get; set; }
        //public DbSet<Label> Labels { get; set; }
        //public DbSet<Layout> Layouts { get; set; }
        //public DbSet<Panel> Panels { get; set; }
        //public DbSet<PanelResult> PanelResults { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        //public DbSet<Report> Reports { get; set; }
        //public DbSet<ReportTemplate> ReportTemplates { get; set; }
        //public DbSet<Specimen> Specimens { get; set; }
        //public DbSet<SpecimenTransport> SpecimenTransports { get; set; }
        //public DbSet<SpecimenType> SpecimenTypes { get; set; }
        //public DbSet<Step> Steps{ get; set; }
        //public DbSet<Test> Tests { get; set; }
        //public DbSet<TestResult> TestResults { get; set; }
        //public DbSet<TestType> TestTypes { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Workflow> Workflows { get; set; }
        //public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        //public DbSet<Worklist> Worklists { get; set; }
        //public DbSet<WorklistColumn> WorklistColumns { get; set; }
        //public DbSet<WorklistConfiguration> WorklistConfigurations{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BaseMap(modelBuilder.Entity<Accession>());
            BaseMap(modelBuilder.Entity<Batch>());
            BaseMap(modelBuilder.Entity<BatchType>());
            BaseMap(modelBuilder.Entity<Case>());
            BaseMap(modelBuilder.Entity<CaseType>());
            BaseMap(modelBuilder.Entity<Client>());
            BaseMap(modelBuilder.Entity<Comment>());
            BaseMap(modelBuilder.Entity<Dashboard>());
            BaseMap(modelBuilder.Entity<DashboardComponent>());
            BaseMap(modelBuilder.Entity<DashboardSection>());
            BaseMap(modelBuilder.Entity<Department>());
            BaseMap(modelBuilder.Entity<Doctor>());
            BaseMap(modelBuilder.Entity<Facility>());
            BaseMap(modelBuilder.Entity<Lab>());
            BaseMap(modelBuilder.Entity<Label>());
            BaseMap(modelBuilder.Entity<Layout>());
            BaseMap(modelBuilder.Entity<Panel>());
            BaseMap(modelBuilder.Entity<PanelResult>());
            BaseMap(modelBuilder.Entity<Patient>());
            BaseMap(modelBuilder.Entity<Report>());
            BaseMap(modelBuilder.Entity<ReportDocument>());
            BaseMap(modelBuilder.Entity<ReportTemplate>());
            BaseMap(modelBuilder.Entity<Specimen>());
            BaseMap(modelBuilder.Entity<SpecimenTransport>());
            BaseMap(modelBuilder.Entity<SpecimenType>());
            BaseMap(modelBuilder.Entity<Step>());
            BaseMap(modelBuilder.Entity<Test>());
            BaseMap(modelBuilder.Entity<TestResult>());
            BaseMap(modelBuilder.Entity<TestType>());
            //BaseMap(modelBuilder.Entity<User>());
            BaseMap(modelBuilder.Entity<Workflow>());
            BaseMap(modelBuilder.Entity<WorkflowStep>());
            BaseMap(modelBuilder.Entity<Worklist>());
            BaseMap(modelBuilder.Entity<WorklistColumn>());
            //BaseMap(modelBuilder.Entity<WorklistConfiguration>());
            
            //data type/field/prop restrictions
            modelBuilder.Entity<Test>().Property(p => p.TestCode).HasMaxLength(6);
            modelBuilder.Entity<Panel>().Property(p => p.PanelCode).HasMaxLength(6);
            modelBuilder.Entity<SpecimenType>().Property(p => p.SpecimenTypeCode).HasMaxLength(3);
            modelBuilder.Entity<SpecimenTransport>().Property(p => p.SpecimenTransportCode).HasMaxLength(3);
            modelBuilder.Entity<Specimen>().Property(p => p.SpecimenCode).HasMaxLength(7);
            modelBuilder.Entity<BatchType>().Property(p => p.BatchPrefix).HasMaxLength(4);
            modelBuilder.Entity<CaseType>().Property(p => p.CaseNumberPrefix).HasMaxLength(4);
            //TODO: set all names and codes required            
        }

        protected void BaseMap<T>(EntityTypeBuilder<T> entityBuilder) where T : _LimsBaseClass
        {
            entityBuilder.HasKey(x => x.GUID);
            entityBuilder.Property(x => x.GUID).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.ModifiedDate).ValueGeneratedOnAddOrUpdate();
            entityBuilder.Property(x => x.CreatedUUID).IsRequired(true);
            entityBuilder.Property(x => x.ModifiedUUID).IsRequired(true);
            entityBuilder.Property(x => x.JsonExtendedData).ForNpgsqlHasColumnType("jsonb");
        }
    }
}
