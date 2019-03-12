using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    interface IObjectMapper
    {
        List<BaseEntity> BuildObjects(List<Dictionary<string,object>> lstRows);
        BaseEntity BuildObject(Dictionary<string, object> row);
    }
}