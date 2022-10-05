using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Schemas
{
    public class AspNetUserRolesSchema
    {
        public static string Table = "aspnetuserroles";

        public static string UserId = "userId";
        public static string RoleId = "roleId";

        public static string QueryFindRolByUser = $"SELECT {RoleId} FROM {Table} WHERE {UserId} = @Usuario";
    }
}