using Movies.Domin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Respository.Mysql.ImplementInterface
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesDbContext _dbContext;
        public MoviesRepository(MoviesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="movies"></param>
        public void Add(Domin.Movies movies)
        {
            _dbContext.Set<Domin.Movies>().Add(movies);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="movies"></param>
        public void Edit(Domin.Movies movies)
        {
            _dbContext.Set<Domin.Movies>().Update(movies);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Domin.Movies> GetList(Expression<Func<Domin.Movies, bool>> condition)
        {
            return _dbContext.Set<Domin.Movies>().Where(condition).ToList();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domin.Movies> GetQueryable()
        {
            return _dbContext.Set<Domin.Movies>();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
