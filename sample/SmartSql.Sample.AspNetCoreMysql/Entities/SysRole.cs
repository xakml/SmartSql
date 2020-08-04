using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSql.Sample.AspNetCoreMysql.Entities
{
    public class SysRole
    {
        #region Constructors

        public SysRole()
        {
            this.Version = 1;
            this.CreatedTime = System.DateTime.Now;

            this.CreatedBy = "测试账号";
            this.LastModifiedBy = "测试账号";
            this.LastModifiedTime = DateTime.Now;
            this.Version = 1;
        }

        #endregion

        /// <summary>
        /// 主键ID,自增
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 记录版本号，主要用于解决并发冲突的乐观锁实现
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 记录创建人
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public System.DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// 最后一次修改人
        /// </summary>
        public string LastModifiedBy { get; set; }

        #region Properties        

        /// <summary>
        /// 中文角色名称
        /// AllowNull: False
        /// Length: 90
        /// </summary>
        public string DisplayCnname { get; set; }

        /// <summary>
        /// 英文角色名称
        /// AllowNull: False
        /// Length: 90
        /// </summary>
        public string DisplayEnname { get; set; }

        /// <summary>
        /// 角色状态(是否可用, 已删除,...等状态)
        /// AllowNull: True
        /// Length: 0
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// AllowNull: True
        /// Length: 300
        /// </summary>
        public string Note { get; set; }
        #endregion

        #region override Mehtods

        public override string ToString()
        {
            return $"Id={Id}, CnName={DisplayCnname}";
        }

        #endregion
    }
}
