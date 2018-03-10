部署说明, 找到根目录下的appsettings.json文件

更改 DbServerName 的值, 目前暂只支持常用的 npgsql, mysql, sqlserver
如果需要支持其他的数据库, 可以自己翻看源码, 使用nuget加上数据库驱动

连接字符串只需要修改下面三个key的值, 
npgsql_connstr
mysql_connstr
sqlserver_connstr

安装.net core 2.x最新版本然后就可以直接再控制台中直接运行

dotnet RecruitWeb.dll

更多部署方式, 例如iis部署, linux部署, 可以看.net core的官方文档