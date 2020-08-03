namespace SmartSql.Sample.AspNetCore2.DTO
{
    /// <summary>
    /// 客户数据查询条件，客户类参考<see cref="Entities.Customer"/>
    /// </summary>
    public class CustomerQueryConditon
    {
        /// <summary>
        /// 查询条件： 客户Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 查询条件： 客户名称
        /// </summary>
        public string Name { get; set; }

        public CustomerQueryConditon() { this.Name = string.Empty; }
        public CustomerQueryConditon(long id) : this() { this.Id = id; }
        public CustomerQueryConditon(string name)
        {
            this.Name = name;
        }
        public CustomerQueryConditon(long id, string name) : this(id)
        {
            this.Name = name;
        }
    }
}
