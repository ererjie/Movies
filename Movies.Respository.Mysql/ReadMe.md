
使用结尾修改为.md时 在.csproj中不能有有和这个文件相关的东西，如果有必须删除
上下文和启动项不在一个类库里用这种写法迁移模型和数据库
dotnet ef migrations add init --startup-project ../Movies

dotnet ef database update --startup-project ../Movies
