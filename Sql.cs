
namespace Sql
{    
    public struct SysSchema
    {
        public string Name;
        public int SchemaID;
        public int PrincipalID;

        public static Sql.SysSchema dbo = new Sql.SysSchema() { Name = "dbo", SchemaID = 1, PrincipalID = 1 };
        public static Sql.SysSchema guest = new Sql.SysSchema() { Name = "guest", SchemaID = 2, PrincipalID = 2 };
        public static Sql.SysSchema INFORMATION_SCHEMA = new Sql.SysSchema() { Name = "INFORMATION_SCHEMA", SchemaID = 3, PrincipalID = 3 };
        public static Sql.SysSchema sys = new Sql.SysSchema() { Name = "sys", SchemaID = 4, PrincipalID = 4 };
        public static Sql.SysSchema db_owner = new Sql.SysSchema() { Name = "db_owner", SchemaID = 16384, PrincipalID = 16384 };
        public static Sql.SysSchema db_accessadmin = new Sql.SysSchema() { Name = "db_accessadmin", SchemaID = 16385, PrincipalID = 16385 };
        public static Sql.SysSchema db_securityadmin = new Sql.SysSchema() { Name = "db_securityadmin", SchemaID = 16386, PrincipalID = 16386 };
        public static Sql.SysSchema db_ddladmin = new Sql.SysSchema() { Name = "db_ddladmin", SchemaID = 16387, PrincipalID = 16387 };
        public static Sql.SysSchema db_backupoperator = new Sql.SysSchema() { Name = "db_backupoperator", SchemaID = 16389, PrincipalID = 16389 };
        public static Sql.SysSchema db_datareader = new Sql.SysSchema() { Name = "db_datareader", SchemaID = 16390, PrincipalID = 16390 };
        public static Sql.SysSchema db_datawriter = new Sql.SysSchema() { Name = "db_datawriter", SchemaID = 16391, PrincipalID = 16391 };
        public static Sql.SysSchema db_denydatareader = new Sql.SysSchema() { Name = "db_denydatareader", SchemaID = 16392, PrincipalID = 16392 };
        public static Sql.SysSchema db_denydatawriter = new Sql.SysSchema() { Name = "db_denydatawriter", SchemaID = 16393, PrincipalID = 16393 };

        public static Sql.SysSchema[] AllSchemas;

        static SysSchema()
        {
            AllSchemas = new Sql.SysSchema[]
            {
                Sql.SysSchema.dbo,
                Sql.SysSchema.guest,
                Sql.SysSchema.INFORMATION_SCHEMA,
                Sql.SysSchema.sys,
                Sql.SysSchema.db_owner,
                Sql.SysSchema.db_accessadmin,
                Sql.SysSchema.db_securityadmin,
                Sql.SysSchema.db_ddladmin,
                Sql.SysSchema.db_backupoperator,
                Sql.SysSchema.db_datareader,
                Sql.SysSchema.db_datawriter,
                Sql.SysSchema.db_denydatareader,
                Sql.SysSchema.db_denydatawriter
            };
        }

    }

    public struct SysType
    {
        public string Name;
        public int SystemTypeID;
        public int UserTypeID;
        public Sql.SysSchema Schema;

        public static Sql.SysType Image  = new Sql.SysType() { Name = "image", SystemTypeID =  34 , UserTypeID =  34 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Text  = new Sql.SysType() { Name = "text", SystemTypeID =  35 , UserTypeID =  35 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType UniqueIdentifier  = new Sql.SysType() { Name = "uniqueidentifier", SystemTypeID =  36 , UserTypeID =  36 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Date  = new Sql.SysType() { Name = "date", SystemTypeID =  40 , UserTypeID =  40 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Time  = new Sql.SysType() { Name = "time", SystemTypeID =  41 , UserTypeID =  41 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType DateTime2  = new Sql.SysType() { Name = "datetime2", SystemTypeID =  42 , UserTypeID =  42 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType DateTimeOffset  = new Sql.SysType() { Name = "datetimeoffset", SystemTypeID =  43 , UserTypeID =  43 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType TinyInt  = new Sql.SysType() { Name = "tinyint", SystemTypeID =  48 , UserTypeID =  48 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType SmallInt  = new Sql.SysType() { Name = "smallint", SystemTypeID =  52 , UserTypeID =  52 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Int  = new Sql.SysType() { Name = "int", SystemTypeID =  56 , UserTypeID =  56 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType SmallDateTime  = new Sql.SysType() { Name = "smalldatetime", SystemTypeID =  58 , UserTypeID =  58 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Real  = new Sql.SysType() { Name = "real", SystemTypeID =  59 , UserTypeID =  59 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Money  = new Sql.SysType() { Name = "money", SystemTypeID =  60 , UserTypeID =  60 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType DateTime  = new Sql.SysType() { Name = "datetime", SystemTypeID =  61 , UserTypeID =  61 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Float  = new Sql.SysType() { Name = "float", SystemTypeID =  62 , UserTypeID =  62 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType sql_variant  = new Sql.SysType() { Name = "sql_variant", SystemTypeID =  98 , UserTypeID =  98 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType NText  = new Sql.SysType() { Name = "ntext", SystemTypeID =  99 , UserTypeID =  99 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Bit  = new Sql.SysType() { Name = "bit", SystemTypeID =  104 , UserTypeID =  104 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Decimal  = new Sql.SysType() { Name = "decimal", SystemTypeID =  106 , UserTypeID =  106 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType numeric  = new Sql.SysType() { Name = "numeric", SystemTypeID =  108 , UserTypeID =  108 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType SmallMoney  = new Sql.SysType() { Name = "smallmoney", SystemTypeID =  122 , UserTypeID =  122 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType BigInt  = new Sql.SysType() { Name = "bigint", SystemTypeID =  127 , UserTypeID =  127 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType hierarchyid  = new Sql.SysType() { Name = "hierarchyid", SystemTypeID =  240 , UserTypeID =  128 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType geometry  = new Sql.SysType() { Name = "geometry", SystemTypeID =  240 , UserTypeID =  129 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType geography  = new Sql.SysType() { Name = "geography", SystemTypeID =  240 , UserTypeID =  130 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType VarBinary  = new Sql.SysType() { Name = "varbinary", SystemTypeID =  165 , UserTypeID =  165 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType VarChar  = new Sql.SysType() { Name = "varchar", SystemTypeID =  167 , UserTypeID =  167 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Binary  = new Sql.SysType() { Name = "binary", SystemTypeID =  173 , UserTypeID =  173 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Char  = new Sql.SysType() { Name = "char", SystemTypeID =  175 , UserTypeID =  175 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Timestamp  = new Sql.SysType() { Name = "timestamp", SystemTypeID =  189 , UserTypeID =  189 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType NVarChar  = new Sql.SysType() { Name = "nvarchar", SystemTypeID =  231 , UserTypeID =  231 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType NChar  = new Sql.SysType() { Name = "nchar", SystemTypeID =  239 , UserTypeID =  239 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType Xml  = new Sql.SysType() { Name = "xml", SystemTypeID =  241 , UserTypeID =  241 , Schema = Sql.SysSchema.sys };
        public static Sql.SysType sysname  = new Sql.SysType() { Name = "sysname", SystemTypeID =  231 , UserTypeID =  256 , Schema = Sql.SysSchema.sys };

        public static Sql.SysType[] AllTypes;

        static SysType()
        {
            AllTypes = new Sql.SysType[]
            {
                Sql.SysType.Image,
                Sql.SysType.Text,
                Sql.SysType.UniqueIdentifier,
                Sql.SysType.Date,
                Sql.SysType.Time,
                Sql.SysType.DateTime2,
                Sql.SysType.DateTimeOffset,
                Sql.SysType.TinyInt,
                Sql.SysType.SmallInt,
                Sql.SysType.Int,
                Sql.SysType.SmallDateTime,
                Sql.SysType.Real,
                Sql.SysType.Money,
                Sql.SysType.DateTime,
                Sql.SysType.Float,
                Sql.SysType.sql_variant,
                Sql.SysType.NText,
                Sql.SysType.Bit,
                Sql.SysType.Decimal,
                Sql.SysType.numeric,
                Sql.SysType.SmallMoney,
                Sql.SysType.BigInt,
                Sql.SysType.hierarchyid,
                Sql.SysType.geometry,
                Sql.SysType.geography,
                Sql.SysType.VarBinary,
                Sql.SysType.VarChar,
                Sql.SysType.Binary,
                Sql.SysType.Char,
                Sql.SysType.Timestamp,
                Sql.SysType.NVarChar,
                Sql.SysType.NChar,
                Sql.SysType.Xml,
                Sql.SysType.sysname
            };
        }

    }

    public struct ObjectType
    {
        public string Type;
        public string TypeName;
        public string TypeDesc;

        public static Sql.ObjectType AF  = new Sql.ObjectType() { Type = "AF", TypeName = "Aggregate function (CLR)", TypeDesc = "AGGREGATE_FUNCTION" };
        public static Sql.ObjectType C  = new Sql.ObjectType() { Type = "C", TypeName = "CHECK constraint", TypeDesc = "CHECK_CONSTRAINT" };
        public static Sql.ObjectType D  = new Sql.ObjectType() { Type = "D", TypeName = "DEFAULT (constraint or stand-alone)", TypeDesc = "DEFAULT_CONSTRAINT" };
        public static Sql.ObjectType F  = new Sql.ObjectType() { Type = "F", TypeName = "FOREIGN KEY constraint", TypeDesc = "FOREIGN_KEY_CONSTRAINT" };
        public static Sql.ObjectType FN  = new Sql.ObjectType() { Type = "FN", TypeName = "SQL scalar function", TypeDesc = "SQL_SCALAR_FUNCTION" };
        public static Sql.ObjectType FS  = new Sql.ObjectType() { Type = "FS", TypeName = "Assembly (CLR) scalar-function", TypeDesc = "CLR_SCALAR_FUNCTION" };
        public static Sql.ObjectType FT  = new Sql.ObjectType() { Type = "FT", TypeName = "Assembly (CLR) table-valued function", TypeDesc = "CLR_TABLE_VALUED_FUNCTION" };
        public static Sql.ObjectType IF  = new Sql.ObjectType() { Type = "IF", TypeName = "SQL inline table-valued function", TypeDesc = "SQL_INLINE_TABLE_VALUED_FUNCTION" };
        public static Sql.ObjectType IT  = new Sql.ObjectType() { Type = "IT", TypeName = "Internal table", TypeDesc = "INTERNAL_TABLE" };
        public static Sql.ObjectType P  = new Sql.ObjectType() { Type = "P", TypeName = "SQL Stored Procedure", TypeDesc = "SQL_STORED_PROCEDURE" };
        public static Sql.ObjectType PC  = new Sql.ObjectType() { Type = "PC", TypeName = "Assembly (CLR) stored-procedure", TypeDesc = "CLR_STORED_PROCEDURE" };
        public static Sql.ObjectType PG  = new Sql.ObjectType() { Type = "PG", TypeName = "Plan guide", TypeDesc = "PLAN_GUIDE" };
        public static Sql.ObjectType PK  = new Sql.ObjectType() { Type = "PK", TypeName = "PRIMARY KEY constraint", TypeDesc = "PRIMARY_KEY_CONSTRAINT" };
        public static Sql.ObjectType R  = new Sql.ObjectType() { Type = "R", TypeName = "Rule (old-style, stand-alone)", TypeDesc = "RULE" };
        public static Sql.ObjectType RF  = new Sql.ObjectType() { Type = "RF", TypeName = "Replication-filter-procedure", TypeDesc = "REPLICATION_FILTER_PROCEDURE" };
        public static Sql.ObjectType S  = new Sql.ObjectType() { Type = "S", TypeName = "System base table", TypeDesc = "SYSTEM_TABLE" };
        public static Sql.ObjectType SN  = new Sql.ObjectType() { Type = "SN", TypeName = "Synonym", TypeDesc = "SYNONYM" };
        public static Sql.ObjectType SO  = new Sql.ObjectType() { Type = "SO", TypeName = "Sequence object", TypeDesc = "SEQUENCE_OBJECT" };
        public static Sql.ObjectType U  = new Sql.ObjectType() { Type = "U", TypeName = "Table (user-defined)", TypeDesc = "USER_TABLE" };
        public static Sql.ObjectType V  = new Sql.ObjectType() { Type = "V", TypeName = "View", TypeDesc = "VIEW" };
        public static Sql.ObjectType EC  = new Sql.ObjectType() { Type = "EC", TypeName = "Edge constraint", TypeDesc = "" };
        public static Sql.ObjectType SQ  = new Sql.ObjectType() { Type = "SQ", TypeName = "Service queue", TypeDesc = "SERVICE_QUEUE" };
        public static Sql.ObjectType TA  = new Sql.ObjectType() { Type = "TA", TypeName = "Assembly (CLR) DML trigger", TypeDesc = "CLR_TRIGGER" };
        public static Sql.ObjectType TF  = new Sql.ObjectType() { Type = "TF", TypeName = "SQL table-valued-function", TypeDesc = "SQL_TABLE_VALUED_FUNCTION" };
        public static Sql.ObjectType TR  = new Sql.ObjectType() { Type = "TR", TypeName = "SQL DML trigger", TypeDesc = "SQL_TRIGGER" };
        public static Sql.ObjectType TT  = new Sql.ObjectType() { Type = "TT", TypeName = "Table type", TypeDesc = "TABLE_TYPE" };
        public static Sql.ObjectType UQ  = new Sql.ObjectType() { Type = "UQ", TypeName = "UNIQUE constraint", TypeDesc = "UNIQUE_CONSTRAINT" };
        public static Sql.ObjectType X  = new Sql.ObjectType() { Type = "X", TypeName = "Extended stored procedure", TypeDesc = "EXTENDED_STORED_PROCEDURE" };
        public static Sql.ObjectType ET  = new Sql.ObjectType() { Type = "ET", TypeName = "External Table", TypeDesc = "" };
        
        public static Sql.ObjectType[] AllObjectTypes;

        static ObjectType()
        {
            AllObjectTypes = new Sql.ObjectType[]
            {
                Sql.ObjectType.AF,
                Sql.ObjectType.C,
                Sql.ObjectType.D,
                Sql.ObjectType.F,
                Sql.ObjectType.FN,
                Sql.ObjectType.FS,
                Sql.ObjectType.FT,
                Sql.ObjectType.IF,
                Sql.ObjectType.IT,
                Sql.ObjectType.P,
                Sql.ObjectType.PC,
                Sql.ObjectType.PG,
                Sql.ObjectType.PK,
                Sql.ObjectType.R,
                Sql.ObjectType.RF,
                Sql.ObjectType.S,
                Sql.ObjectType.SN,
                Sql.ObjectType.SO,
                Sql.ObjectType.U,
                Sql.ObjectType.V,
                Sql.ObjectType.EC,
                Sql.ObjectType.SQ,
                Sql.ObjectType.TA,
                Sql.ObjectType.TF,
                Sql.ObjectType.TR,
                Sql.ObjectType.TT,
                Sql.ObjectType.UQ,
                Sql.ObjectType.X,
                Sql.ObjectType.ET
            };
        }
    }
    
    public class SysObject
    {
        public string Name;
        public Sql.ObjectType ObjectType;
    }

    public class UserTable : Sql.SysObject
    {

    }

    public class SqlStoredProcedure : Sql.SysObject
    {
        
    }

    public class Column
    {
        public Sql.SysObject Object;
        public string Name;
        public Sql.SysType SystemType;
        public short MaxLength; 
        
        public bool IsNullable;
        public bool IsIdentity;
    }

    public class Parameter
    {
        public Sql.SysObject Object;
        public string Name;
        public Sql.SysType SystemType;
        public short MaxLength;
        
        public bool IsOutput;
        public bool IsNullable;
    }
}
