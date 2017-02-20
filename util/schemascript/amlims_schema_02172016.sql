--
-- Name: Client; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Client (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    ClientCode text,
    ClientName text,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    ID integer NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);



--
-- Name: Lab; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Lab (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    LabCode text,
    LabName text,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);


--
-- Name: Doctor; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Doctor (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    ClientID integer NOT NULL PRIMARY KEY REFERENCES Client,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    FirstName text,
    JsonExtendedData jsonb,
    LastName text,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);


CREATE TABLE Accession (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    Doctor2ID integer NOT NULL PRIMARY KEY REFERENCES Doctor,
    JsonExtendedData jsonb,
    MRN text,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    Doctor1ID integer NOT NULL PRIMARY KEY REFERENCES Doctor
);


--
-- Name: Batch; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Batch (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    BatchNumber text,
    BatchStatus text,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);


--
-- Name: Case; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Case (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    AccessionID integer NOT NULL PRIMARY KEY REFERENCES Accession,
    AnalysisLabID integer NOT NULL PRIMARY KEY REFERENCES Lab,
    CaseNumber text,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    ProcessingLabID integer NOT NULL PRIMARY KEY REFERENCES Lab,
    ProfessionalLabID integer NOT NULL PRIMARY KEY REFERENCES Lab
);



--
-- Name: Facility; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Facility (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    AddressLine1 text,
    AddressLine2 text,
    City text,
    ClientID integer NOT NULL PRIMARY KEY REFERENCES Client,
    Country text,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    Name text,
    PostalCode text,
    StateProvince text
);



--
-- Name: Label; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Label (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    BarcodeFormDefinition text,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    LabelName text,
    LabelType integer NOT NULL,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);


--
-- Name: PanelResult; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE PanelResult (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CaseID integer NOT NULL PRIMARY KEY REFERENCES Case,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);


--
-- Name: Patient; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Patient (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    DOB timestamp without time zone NOT NULL,
    FirstName text,
    JsonExtendedData jsonb,
    LastName text,
    MiddleName text,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    SSN text
);


--
-- Name: Report; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Report (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CaseID integer,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    ReportVersion integer NOT NULL,
    ReportVersionNotes text
);


--
-- Name: ReportDocument; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE ReportDocument (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    ReportDocumentBinary bytea,
    ReportDocumentType integer NOT NULL,
    ReportID integer NOT NULL PRIMARY KEY REFERENCES Report
);


--
-- Name: ReportTemplate; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE ReportTemplate (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    PublicReport boolean NOT NULL,
    ReportTemplateDefinition text,
    ReportTemplateName text
);


--
-- Name: Specimen; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Specimen (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    AccessionID integer NOT NULL PRIMARY KEY REFERENCES Accession,
    BatchID integer NOT NULL PRIMARY KEY REFERENCES Batch,
    CaseID integer NOT NULL PRIMARY KEY REFERENCES Case,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    ExternalSpecimenID text,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    SpecimenCode character varying(7)
);



--
-- Name: Workflow; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Workflow (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    WorkflowName text
);

--
-- Name: Step; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE Step (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL,
    WorkflowStepName text,
    WorkflowID integer NOT NULL REFERENCES Workflow
);


--
-- Name: TestResult; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE TestResult (
    ID integer NOT NULL PRIMARY KEY,
    Active boolean NOT NULL,
    BatchID integer NOT NULL PRIMARY KEY REFERENCES Batch,
    CaseID integer NOT NULL PRIMARY KEY REFERENCES Case, 
    CreatedDate timestamp without time zone NOT NULL,
    CreatedUUID text NOT NULL,
    JsonExtendedData jsonb,
    ModifiedDate timestamp without time zone NOT NULL,
    ModifiedUUID text NOT NULL
);



