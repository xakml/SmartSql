﻿using SmartSql.DyRepository.Annotations;
using SmartSql.Test.DTO;
using SmartSql.Test.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSql.Sample.Repos
{
    public interface IUserRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(User entity);
        Task<long> InsertAsync(User entity);
        [Statement(Id = "GetEntity")]
        User GetById([Param("Id")] long id);
        IEnumerable<User> Query([Param("Taken")] int taken);
        [Statement(Id = "QueryByPage")]
        Task<TPageResult> GetByPage<TPageResult>(object request);
        Task<IEnumerable<User>> QueryAsync([Param("Taken")] int taken);
        int Update(User entity);

        IEnumerable<UserVW> GetVWList();
    }
}
