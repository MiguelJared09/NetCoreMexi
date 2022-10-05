using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Schemas
{
    public class RolAccesoSchema
    {
        public static string Table = "rolAccesos";

        public static string RoleId = "roleId";
        public static string Acceso = "acceso";

        public static string QueryListByRole = $"SELECT * FROM {Table} WHERE {RoleId} = @Role";
        public static string QueryListByUser = $"SELECT * FROM {Table} WHERE {RoleId} IN ({AspNetUserRolesSchema.QueryFindRolByUser})";
        public static string QueryListUniqueAccesosByUser = $"SELECT DISTINCT {Acceso} FROM {Table} WHERE {RoleId} IN ({AspNetUserRolesSchema.QueryFindRolByUser})";
    }
}