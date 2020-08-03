## 1.引用原始项目的示例应用程序

#### 1.1 相关配置如下

1. SmartSqlMapConfig.xml
```xml
<?xml version="1.0" encoding="utf-8" ?>
<SmartSqlMapConfig xmlns="http://SmartSql.net/schemas/SmartSqlMapConfig.xsd">
	<Settings IgnoreParameterCase="false" ParameterPrefix="$" IsCacheEnabled="true" EnablePropertyChangedTrack="true"/>
	<Database>
		<!--这里使用Sqlite数据， 在.netcore2.2中使用版本System.Data.SQLite(1.0.111)-->
		<!--这里使用Sqlite数据， 在.netcore3.1中使用版本System.Data.SQLite(1.0.113.1)-->
		<DbProvider Name="SQLite"/>
		<Write Name="WriteDB" ConnectionString="${ConnectionString}"/>
		<Read Name="ReadDb-1" ConnectionString="${ConnectionString}" Weight="100"/>
		<Read Name="ReadDb-2" ConnectionString="${ConnectionString}" Weight="100"/>
	</Database>
	<SmartSqlMaps>
		<SmartSqlMap Path="Maps" Type="Directory"></SmartSqlMap>
	</SmartSqlMaps>
</SmartSqlMapConfig>

```

#### 1.2 需要引用的必要项目如下
> SmartSql.DIExtension.dll  
	SmartSql.DyRepository.dll  
	SmartSql.InvokeSync.dll  
	SmartSql.ScriptTag.dll  
	SmartSql.Test.dll  
	SmartSql.TypeHandler.dll  
	SmartSql.dll  
