using SmartSql.DyRepository.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSql.Sample.AspNetCoreMysql.DyRepositories
{
    public interface ISysRoleRepository
    {
        ISqlMapper SqlMapper { get; }

        [Statement(Id = "SelectSysRoleById")]
        Entities.SysRole SelectSysRoleById([Param("Id")] long id);
    }
}
