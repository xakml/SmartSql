
# Clone from ([dotnetcore](https://github.com/dotnetcore/SmartSql))

<p align="center">
  <a href="https://smartsql.net/en/" target="_blank">
    <img width="100"src="./SmartSql.png"/>
  </a>
</p>

# Overview

> 官方文档请访问
> https://github.com/dotnetcore/SmartSql/blob/master/README.md
---


## 入门问题总结

入门使用过程中参考了不少官方的文档， 大部分都是整体的概述， 很多细节容易出错的地方没讲到，这里总结一些我自己遇到的小问题（netcore平台的优质ORM框架实在不好找， 那就出一份里来维护这个看起来还不错的开源项目吧）

## 简单对象的操作操作
第一步:   
   关键点整体配置文件
```xml
<?xml version="1.0" encoding="utf-8" ?>
<SmartSqlMapConfig xmlns="http://SmartSql.net/schemas/SmartSqlMapConfig.xsd">
  <Settings 
    IgnoreParameterCase="false" 
    ParameterPrefix="$"  
    IsCacheEnabled="true" 
    EnablePropertyChangedTrack="true" 
    IgnoreDbNull="true"/>
  <Properties>
    <!-- 此处省略一些常见的自定义参数设置 -->
  </Properties>

</SmartSqlMapConfig>
```

>重点来了  
> 参数 **ParameterPrefix="$"** , 这里需要设置sql语句的参数占位符前缀字符, 一般情况下用的比较多的是@符号.  
> 通常情况下容易忽略此处的设置

