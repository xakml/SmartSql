﻿using SmartSql.TypeHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public string Schema { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SmartSqlTableAttribute : TableAttribute 
    {
        public SmartSqlTableAttribute(String tableName):base(tableName)
        {
                
        }
    }
}
