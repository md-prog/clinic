using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.Models;

namespace ArsMachinaLIMSDAL.Migrations
{
    [DbContext(typeof(ArsMachinaLIMSContext))]
    [Migration("20170126173540_MoveDB")]
    partial class MoveDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("Doctor2GUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("MRN");

                    b.HasKey("GUID");

                    b.HasIndex("Doctor2GUID");

                    b.ToTable("Accession");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Batch", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("BatchNumber");

                    b.Property<string>("BatchStatus");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.HasKey("GUID");

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.BatchType", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("AllowAddOnStartingStepOnly");

                    b.Property<int>("BatchItemType");

                    b.Property<string>("BatchPrefix")
                        .HasMaxLength(4);

                    b.Property<int>("BatchRestrictionType");

                    b.Property<string>("BatchTypeName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("StartingStepGUID");

                    b.HasKey("GUID");

                    b.HasIndex("StartingStepGUID");

                    b.ToTable("BatchType");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("AnalysisLabGUID");

                    b.Property<string>("CaseNumber");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("ProcessingLabGUID");

                    b.Property<Guid?>("ProfessionalLabGUID");

                    b.HasKey("GUID");

                    b.HasIndex("AnalysisLabGUID");

                    b.HasIndex("ProcessingLabGUID");

                    b.HasIndex("ProfessionalLabGUID");

                    b.ToTable("Case");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.CaseType", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CaseNumberPrefix")
                        .HasMaxLength(4);

                    b.Property<string>("CaseTypeName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("ReportTemplateGUID");

                    b.HasKey("GUID");

                    b.HasIndex("ReportTemplateGUID");

                    b.ToTable("CaseType");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Client", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ClientCode");

                    b.Property<string>("ClientName");

                    b.Property<int>("ID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("UserGUID");

                    b.HasKey("GUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Comment", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccessionGUID");

                    b.Property<bool>("Active");

                    b.Property<Guid?>("CaseGUID");

                    b.Property<Guid?>("ClientGUID");

                    b.Property<string>("CommentText");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("SecondaryIdentifier");

                    b.Property<Guid?>("SpecimenGUID");

                    b.HasKey("GUID");

                    b.HasIndex("AccessionGUID");

                    b.HasIndex("CaseGUID");

                    b.HasIndex("ClientGUID");

                    b.HasIndex("SpecimenGUID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Dashboard", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("DashboardName");

                    b.Property<int>("DashboardType");

                    b.Property<bool>("DefaultDashboard");

                    b.Property<Guid?>("HeaderSectionGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("LeftSectionGUID");

                    b.Property<Guid?>("RightSectionGUID");

                    b.HasKey("GUID");

                    b.HasIndex("HeaderSectionGUID");

                    b.HasIndex("LeftSectionGUID");

                    b.HasIndex("RightSectionGUID");

                    b.ToTable("Dashboard");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.DashboardComponent", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ComponentAngular2CSS");

                    b.Property<string>("ComponentAngular2HTMLTemplate");

                    b.Property<string>("ComponentAngular2Path");

                    b.Property<string>("DashboardComponentName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.HasKey("GUID");

                    b.ToTable("DashboardComponent");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.DashboardSection", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("DashboardSectionName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.HasKey("GUID");

                    b.ToTable("DashboardSection");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Department", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("DepartmentName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("UserGUID");

                    b.HasKey("GUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("ClientGUID");

                    b.Property<string>("FirstName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LastName");

                    b.HasKey("GUID");

                    b.HasIndex("ClientGUID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<Guid?>("ClientGUID");

                    b.Property<string>("Country");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.HasKey("GUID");

                    b.HasIndex("ClientGUID");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Lab", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LabCode");

                    b.Property<string>("LabName");

                    b.Property<Guid?>("UserGUID");

                    b.HasKey("GUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("Lab");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Label", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("BarcodeFormDefinition");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LabelName");

                    b.Property<int>("LabelType");

                    b.HasKey("GUID");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Layout", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.HasKey("GUID");

                    b.ToTable("Layout");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Panel", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("PanelCode")
                        .HasMaxLength(6);

                    b.Property<string>("PanelDescription");

                    b.Property<string>("PanelName");

                    b.HasKey("GUID");

                    b.ToTable("Panel");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("CaseGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("PanelGUID");

                    b.HasKey("GUID");

                    b.HasIndex("CaseGUID");

                    b.HasIndex("PanelGUID");

                    b.ToTable("PanelResult");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Patient", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("SSN");

                    b.HasKey("GUID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("CaseGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<int>("ReportVersion");

                    b.Property<string>("ReportVersionNotes");

                    b.HasKey("GUID");

                    b.HasIndex("CaseGUID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<byte[]>("ReportDocumentBinary");

                    b.Property<int>("ReportDocumentType");

                    b.Property<Guid?>("ReportGUID");

                    b.HasKey("GUID");

                    b.HasIndex("ReportGUID");

                    b.ToTable("ReportDocument");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportTemplate", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<bool>("PublicReport");

                    b.Property<string>("ReportTemplateDefinition");

                    b.Property<string>("ReportTemplateName");

                    b.HasKey("GUID");

                    b.ToTable("ReportTemplate");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("BatchGUID");

                    b.Property<Guid?>("CaseGUID");

                    b.Property<string>("ExternalSpecimenID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("SpecimenCode")
                        .HasMaxLength(7);

                    b.Property<Guid?>("SpecimenGUID");

                    b.Property<Guid?>("SpecimenTransportGUID");

                    b.Property<Guid?>("SpecimenTypeGUID");

                    b.HasKey("GUID");

                    b.HasIndex("BatchGUID");

                    b.HasIndex("CaseGUID");

                    b.HasIndex("SpecimenGUID");

                    b.HasIndex("SpecimenTransportGUID");

                    b.HasIndex("SpecimenTypeGUID");

                    b.ToTable("Specimen");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.SpecimenTransport", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("BatchTypeGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("SpecimenTransportCode")
                        .HasMaxLength(3);

                    b.Property<string>("SpecimenTransportName");

                    b.HasKey("GUID");

                    b.HasIndex("BatchTypeGUID");

                    b.ToTable("SpecimenTransport");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.SpecimenType", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("BatchTypeGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("SpecimenTypeCode")
                        .HasMaxLength(3);

                    b.Property<string>("SpecimenTypeName");

                    b.HasKey("GUID");

                    b.HasIndex("BatchTypeGUID");

                    b.ToTable("SpecimenType");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("LayoutGUID");

                    b.Property<string>("WorkflowStepName");

                    b.HasKey("GUID");

                    b.HasIndex("LayoutGUID");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Test", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("TestCode")
                        .HasMaxLength(6);

                    b.Property<string>("TestName");

                    b.Property<Guid?>("TestTypeGUID");

                    b.HasKey("GUID");

                    b.HasIndex("TestTypeGUID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("BatchGUID");

                    b.Property<Guid?>("CaseGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("PanelGUID");

                    b.Property<Guid?>("TestGUID");

                    b.HasKey("GUID");

                    b.HasIndex("BatchGUID");

                    b.HasIndex("CaseGUID");

                    b.HasIndex("PanelGUID");

                    b.HasIndex("TestGUID");

                    b.ToTable("TestResult");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestType", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid?>("BatchTypeGUID");

                    b.Property<Guid?>("CaseTypeGUID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("TestTypeCode");

                    b.Property<string>("TestTypeName");

                    b.HasKey("GUID");

                    b.HasIndex("BatchTypeGUID");

                    b.HasIndex("CaseTypeGUID");

                    b.ToTable("TestType");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.User", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("AllClients");

                    b.Property<string>("Credentials");

                    b.Property<string>("DotNetTimeZone");

                    b.Property<string>("IdentityReferenceID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("PrimaryGroupReferenceID");

                    b.Property<Guid?>("PrimaryLabGUID");

                    b.HasKey("GUID");

                    b.HasIndex("PrimaryLabGUID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Workflow", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("WorkflowName");

                    b.Property<int>("WorkflowType");

                    b.HasKey("GUID");

                    b.ToTable("Workflow");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorkflowStep", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<Guid?>("StepGUID");

                    b.Property<int>("StepOrder");

                    b.Property<Guid?>("WorkflowGUID");

                    b.HasKey("GUID");

                    b.HasIndex("StepGUID");

                    b.HasIndex("WorkflowGUID");

                    b.ToTable("WorkflowStep");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Worklist", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<int>("WorklistType");

                    b.HasKey("GUID");

                    b.ToTable("Worklist");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorklistColumn", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<int>("WorklistColumnDataType");

                    b.Property<int>("WorklistColumnLinkType");

                    b.Property<string>("WorklistColumnName");

                    b.Property<Guid?>("WorklistGUID");

                    b.HasKey("GUID");

                    b.HasIndex("WorklistGUID");

                    b.ToTable("WorklistColumn");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorklistConfiguration", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Default");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<bool>("Public");

                    b.Property<string>("WorklistConfigurationName");

                    b.Property<Guid?>("WorklistGUID");

                    b.HasKey("GUID");

                    b.HasIndex("WorklistGUID");

                    b.ToTable("WorklistConfiguration");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Doctor", "Doctor2")
                        .WithMany()
                        .HasForeignKey("Doctor2GUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.BatchType", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithOne("BatchType")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.BatchType", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Step", "StartingStep")
                        .WithMany()
                        .HasForeignKey("StartingStepGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "AnalysisLab")
                        .WithMany()
                        .HasForeignKey("AnalysisLabGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProcessingLab")
                        .WithMany()
                        .HasForeignKey("ProcessingLabGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProfessionalLab")
                        .WithMany()
                        .HasForeignKey("ProfessionalLabGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.CaseType", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithOne("CaseType")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.CaseType", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.ReportTemplate")
                        .WithMany("CaseTypes")
                        .HasForeignKey("ReportTemplateGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Client", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithOne("Client")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Client", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.User")
                        .WithMany("Clients")
                        .HasForeignKey("UserGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Comment", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithMany("Comments")
                        .HasForeignKey("AccessionGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("Comments")
                        .HasForeignKey("CaseGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Comments")
                        .HasForeignKey("ClientGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Specimen")
                        .WithMany("Comments")
                        .HasForeignKey("SpecimenGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Dashboard", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.DashboardSection", "HeaderSection")
                        .WithMany()
                        .HasForeignKey("HeaderSectionGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.DashboardSection", "LeftSection")
                        .WithMany()
                        .HasForeignKey("LeftSectionGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.DashboardSection", "RightSection")
                        .WithMany()
                        .HasForeignKey("RightSectionGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Department", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.User")
                        .WithMany("Departments")
                        .HasForeignKey("UserGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Doctors")
                        .HasForeignKey("ClientGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithOne("Doctor1")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Doctor", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Facilities")
                        .HasForeignKey("ClientGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithOne("Facility")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Facility", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Lab", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithOne("OrderingLab")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Lab", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.User")
                        .WithMany("Labs")
                        .HasForeignKey("UserGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("PanelResults")
                        .HasForeignKey("CaseGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Panel", "Panel")
                        .WithMany()
                        .HasForeignKey("PanelGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Patient", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithOne("Patient")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Patient", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Report")
                        .WithMany("ReportDocuments")
                        .HasForeignKey("ReportGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportTemplate", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Report")
                        .WithOne("ReportTemplate")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.ReportTemplate", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("Specimens")
                        .HasForeignKey("BatchGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("Specimens")
                        .HasForeignKey("CaseGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Specimen")
                        .WithMany("ChildSpecimens")
                        .HasForeignKey("SpecimenGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.SpecimenTransport", "SpecimenTransport")
                        .WithMany()
                        .HasForeignKey("SpecimenTransportGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.SpecimenType", "SpecimenType")
                        .WithMany()
                        .HasForeignKey("SpecimenTypeGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.SpecimenTransport", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.BatchType")
                        .WithMany("SpecimenTransports")
                        .HasForeignKey("BatchTypeGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.SpecimenType", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.BatchType")
                        .WithMany("SpecimentTypes")
                        .HasForeignKey("BatchTypeGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.BatchType")
                        .WithOne("FinalStep")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Step", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Layout", "Layout")
                        .WithMany()
                        .HasForeignKey("LayoutGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Test", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.TestType", "TestType")
                        .WithMany()
                        .HasForeignKey("TestTypeGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("TestResults")
                        .HasForeignKey("BatchGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("TestResults")
                        .HasForeignKey("CaseGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Panel", "Panel")
                        .WithMany()
                        .HasForeignKey("PanelGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestType", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.BatchType")
                        .WithMany("TestTypes")
                        .HasForeignKey("BatchTypeGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.CaseType")
                        .WithMany("TestTypes")
                        .HasForeignKey("CaseTypeGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.User", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "PrimaryLab")
                        .WithMany()
                        .HasForeignKey("PrimaryLabGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Workflow", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.BatchType")
                        .WithOne("BatchOperationalWorkflow")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.Workflow", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorkflowStep", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Step", "Step")
                        .WithMany()
                        .HasForeignKey("StepGUID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Workflow", "Workflow")
                        .WithMany()
                        .HasForeignKey("WorkflowGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorklistColumn", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Worklist")
                        .WithMany("AvailableColumns")
                        .HasForeignKey("WorklistGUID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.WorklistConfiguration", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.User")
                        .WithOne("WorklistConfiguration")
                        .HasForeignKey("ClinicaCloudPlatform.Model.Models.WorklistConfiguration", "GUID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Worklist", "Worklist")
                        .WithMany()
                        .HasForeignKey("WorklistGUID");
                });
        }
    }
}
