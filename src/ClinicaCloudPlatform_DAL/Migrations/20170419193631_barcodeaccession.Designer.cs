using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.Models;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    [DbContext(typeof(ArsMachinaLIMSContext))]
    [Migration("20170419193631_barcodeaccession")]
    partial class barcodeaccession
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<int?>("Doctor1Id");

                    b.Property<int?>("Doctor2Id");

                    b.Property<int?>("FacilityId");

                    b.Property<Guid>("Guid");

                    b.Property<string>("MRN");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("OrderingLabId");

                    b.Property<int?>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Doctor1Id");

                    b.HasIndex("Doctor2Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("OrderingLabId");

                    b.HasIndex("PatientId");

                    b.ToTable("Accessions");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Barcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<Guid>("AccessionGuid");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Barcodes");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("BatchNumber");

                    b.Property<string>("BatchStatus");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<int>("CurrentTypeSequenceNumber");

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("AccessionId");

                    b.Property<bool>("Active");

                    b.Property<int?>("AnalysisLabId");

                    b.Property<string>("CaseNumber");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<int>("CurrentTypeSequenceNumber");

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("ProcessingLabId");

                    b.Property<int?>("ProfessionalLabId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccessionId");

                    b.HasIndex("AnalysisLabId");

                    b.HasIndex("ProcessingLabId");

                    b.HasIndex("ProfessionalLabId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CommentText");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName");

                    b.Property<string>("CreatedHref");

                    b.Property<string>("CustomData");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName");

                    b.Property<string>("ModifiedHref");

                    b.Property<string>("SecondaryIdentifier");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("FirstName");

                    b.Property<Guid>("Guid");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<int?>("ClientId");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Lab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("BarcodeFormDefinition");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<string>("LabelName");

                    b.Property<int>("LabelType");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("CaseId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("PanelCode");

                    b.Property<string>("PanelName");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("PanelResults");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName");

                    b.Property<Guid>("Guid");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("SSN");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("CaseId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("ReportTemplateId");

                    b.Property<int>("ReportVersion");

                    b.Property<string>("ReportVersionNotes");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("ReportTemplateId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<byte[]>("ReportDocumentBinary");

                    b.Property<int>("ReportDocumentType");

                    b.Property<int?>("ReportId");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportDocument");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<bool>("PublicReport");

                    b.Property<string>("ReportTemplateDefinition");

                    b.Property<string>("ReportTemplateName");

                    b.HasKey("Id");

                    b.ToTable("ReportTemplates");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("AccessionId");

                    b.Property<bool>("Active");

                    b.Property<int?>("BatchId");

                    b.Property<int?>("CaseId");

                    b.Property<string>("Category");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CollectionDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("ExternalID");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<Guid>("ParentSpecimenGuid");

                    b.Property<DateTime>("ReceivedDate");

                    b.Property<string>("Transport");

                    b.Property<string>("TransportCode");

                    b.Property<string>("Type");

                    b.Property<string>("TypeCode");

                    b.HasKey("Id");

                    b.HasIndex("AccessionId");

                    b.HasIndex("BatchId");

                    b.HasIndex("CaseId");

                    b.ToTable("Specimens");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int?>("WorkflowId");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("BatchId");

                    b.Property<int?>("CaseId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("TestCode");

                    b.Property<string>("TestName");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("CaseId");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("CustomData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("WorkflowName");

                    b.HasKey("Id");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Doctor", "Doctor1")
                        .WithMany()
                        .HasForeignKey("Doctor1Id");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Doctor", "Doctor2")
                        .WithMany()
                        .HasForeignKey("Doctor2Id");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "OrderingLab")
                        .WithMany()
                        .HasForeignKey("OrderingLabId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithMany("Cases")
                        .HasForeignKey("AccessionId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "AnalysisLab")
                        .WithMany()
                        .HasForeignKey("AnalysisLabId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProcessingLab")
                        .WithMany()
                        .HasForeignKey("ProcessingLabId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProfessionalLab")
                        .WithMany()
                        .HasForeignKey("ProfessionalLabId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Doctors")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Facilities")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("PanelResults")
                        .HasForeignKey("CaseId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.ReportTemplate", "ReportTemplate")
                        .WithMany()
                        .HasForeignKey("ReportTemplateId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Report")
                        .WithMany("ReportDocuments")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithMany("Specimens")
                        .HasForeignKey("AccessionId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("Specimens")
                        .HasForeignKey("BatchId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("Specimens")
                        .HasForeignKey("CaseId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Workflow")
                        .WithMany("Steps")
                        .HasForeignKey("WorkflowId");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("TestResults")
                        .HasForeignKey("BatchId");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("TestResults")
                        .HasForeignKey("CaseId");
                });
        }
    }
}
