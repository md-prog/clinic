using System;

namespace ClinicaCloudPlatform.Model.Models
{
    public abstract class _LimsBaseClass //: IJsonModel, IAuditable
    {
        
        public _LimsBaseClass()
        {
            ID = 0;
            //AuditLevel = AuditLevel.UserDateOnly;
            //AuditLogReturnLevel = AuditLogReturnLevel.Created;
            Active = true;
        }

        //public AuditLevel AuditLevel { get; set; }
        //public AuditLogReturnLevel AuditLogReturnLevel { get; set; }

        /// <summary>
        /// Managed in code, expects to be persisted in DBMS as unique identifier or index
        /// </summary>
        public int ID { get; set; }
        public bool Active { get; set; }
        public string CreatedUUID { get; set; }
        public string ModifiedUUID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Use to store extended data (or majority of object) as JSON column/document
        /// </summary>
        public string JsonExtendedData { get; set; }

        //public static JsonSchema JsonExtendedDataSchema { get; }

        /// <summary>
        /// Optional inclusion of auditlog for current object
        /// </summary>
        //public ICollection<Audit> AuditLog
        //{
        //    get
        //    {
        //        var retVal = new List<Audit>();
        //        if (AuditLogReturnLevel != AuditLogReturnLevel.None)
        //        {
        //            //retval = list od json diffs from db
        //            //TODO - use https://github.com/FxKu/audit to handle auditing 
        //            switch (AuditLogReturnLevel)
        //            {
        //                case AuditLogReturnLevel.Created:
        //                case AuditLogReturnLevel.LastModified:
        //                case AuditLogReturnLevel.FullHistory:
        //                default:
        //                    retVal = new List<Audit>();
        //                    break;
        //            }
        //        }
        //        return retVal;
        //    }
        //}        

        /// <summary>
        /// Optional usage: get a schema for json validation against the type of this object
        /// Properties that not conform to this schema may not be serialized (TBD feature)
        /// </summary>
        /// <returns>JSON Schema as String - compatible with JSON.Net and possible other JSON libraries (unknown)</returns>
        //public string GetNewtonJsonSchema()
        //{
        //    var schema = new JsonSchema();
        //    var generator = new JsonSchemaGenerator();
        //    schema = generator.Generate(this.GetType());
        //    return schema.ToString();
        //}

        /// <summary>
        /// Returns a JSON string representation of the current object
        /// </summary>
        /// <returns></returns>
        //public override string ToString()
        //{
        //    //this may not be the best performance
        //    var retVal = "";
        //    var serializer = new JsonSerializer();
        //    var textStream = new System.IO.MemoryStream();
        //    var textWriter = new System.IO.StreamWriter(textStream);
        //    var writer = new JsonTextWriter(textWriter);
        //    serializer.Serialize(writer, this);
        //    writer.WriteRaw(retVal);
        //    return retVal;

        //}

        /// <summary>
        /// Get current object as a .Net dynamic type so client deserialization is unecessary
        /// </summary>
        /// <returns>.Net dynamic object</returns>
        //public dynamic GetObject()
        //{
        //    return (dynamic)this;
        //}

    }
}
