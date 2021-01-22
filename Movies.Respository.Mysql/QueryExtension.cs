using EInfrastructure.Core.Config.Entities.Ioc;
using Movies.Respository.Mysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Infrastructure
{
    public static class QueryExtension
    {
        /// <summary>
        /// 得到实体列表
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="exp">条件</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static List<MoviesAccount> GetList<MoviesAccount, T>(this MoviesDbContext dbContext, Expression<Func<MoviesAccount, bool>> exp)
            where MoviesAccount : class, IEntity<T>
        {
            return dbContext.Set<MoviesAccount>()
                .Where(exp).ToList();
        }
    }
}
