using EInfrastructure.Core.Config.Entities.Ioc;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Respository.Mysql
{
    public class MoviesDbContext : DbContext, IUnitOfWork, IPerRequest
    {
        /// <summary>
        /// 实现基类接口
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            //SaveChanges()可以一次将多个操作保存入库（添加、修改、删除）
            this.SaveChanges();
            return true;
        }

        /// <summary>
        /// 实现基类接口（暂时没有用到）
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private readonly AppConfig _appConfig;

        #region 有参构造函数（连接数据库）
        /// <summary>
        /// 有参构造函数（连接数据库）
        /// </summary>
        /// <param name="appConfig"></param>
        public MoviesDbContext(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        #endregion

        #region 部分注入不进去然后就进入这个无参构造函数，使映射能进到数据库
        /// <summary>
        /// 部分注入不进去然后就进入这个无参构造函数，使能连接到数据库
        /// </summary>
        public MoviesDbContext()
        {
            if (_appConfig == null)
            {
                _appConfig = new TestOptions().Value;
            }
        }
        #endregion

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //连接数据库UseMySql关键词
            //MaxBatchSize一个指示将编译为单个批处理的最大页数的整数值。 默认页数为 1000。(当前最大处理量是30条)
            optionsBuilder.UseMySql(_appConfig.DbConn, b => b.MaxBatchSize(30));
        }

        /// <summary>
        /// 映射数据库map
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AutoMap(typeof(MoviesDbContext));//AutoMap会自动寻找实现IEntityMap<模型类>，并且完成map映射
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal) && p.Relational().ColumnType == null))
            {
                //如果map里面没有对decimal大小限制，就用这个方法限制
                property.Relational().ColumnType = "decimal(18,2)";
            }
        }

    }
    public class TestOptions
    {
        public AppConfig Value => new AppConfig()
        {
            DbConn = "Server=localhost;port=3306;database=movies;uid=root;pwd=root;"
        };
    }

}
