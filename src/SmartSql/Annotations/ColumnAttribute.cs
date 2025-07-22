using System;
using System.Reflection;
using SmartSql.TypeHandlers;

namespace SmartSql.Annotations
{
    /// <summary>
    /// ColumnAttribute 的友好名称
    /// <para>请优先使用：SmartSqlColumnAttribute</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute()
        {
        }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int? Ordinal { get; set; }
        public PropertyInfo Property { get; set; }
        public Type FieldType { get; set; }
        public Func<object, object> GetPropertyValue { get; set; }
        /// <summary>
        /// 列名称（数据库）
        /// </summary>
        public string Name { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrement { get; set; }
        public String Alias { get; set; } = SmartSqlBuilder.DEFAULT_ALIAS;
        public String TypeHandler { get; set; }
        public ITypeHandler Handler { get; set; }
    }

    /// <summary>
    /// ColumnAttribute 的友好名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SmartSqlColumnAttribute : ColumnAttribute
    {
        public SmartSqlColumnAttribute(string colName):base(colName)
        {
          
        }

    }
}