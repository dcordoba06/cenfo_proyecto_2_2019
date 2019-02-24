using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;

namespace DataAcess.Mapper
{
    public class AppMessageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TEXT = "TEXT";

        

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MESSAGE_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_COL_ID),
                Message = GetStringValue(row, DB_COL_TEXT)
            };

            return appMessage;
        }
    }
}
