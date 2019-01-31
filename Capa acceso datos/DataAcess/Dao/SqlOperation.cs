using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAcess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set;}

        public SqlOperation()
        {
            Parameters=new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue                            
            };
            Parameters.Add(param);
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDoubleParam(string paramName, double paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }
    }
}
