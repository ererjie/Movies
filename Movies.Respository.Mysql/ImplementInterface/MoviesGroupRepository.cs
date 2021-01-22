using Movies.Domin;
using Movies.Domin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Respository.Mysql.ImplementInterface
{
    /// <summary>
    /// 分组实现类
    /// </summary>
    public class MoviesGroupRepository: IMoviesGroupRepository
    {
        private readonly MoviesDbContext _dbContext;

        public MoviesGroupRepository(MoviesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moviesGroup"></param>
        public void Add(MoviesGroup moviesGroup)
        {
            _dbContext.Set<MoviesGroup>().Add(moviesGroup);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moviesGroup"></param>
        public void Edit(MoviesGroup moviesGroup)
        {
            _dbContext.Set<MoviesGroup>().Update(moviesGroup);
        }
        #endregion

        #region 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<MoviesGroup> GetList(Expression<Func<MoviesGroup, bool>> condition)
        {
            return _dbContext.Set<MoviesGroup>().Where(condition).ToList();
        }
        #endregion

        #region  详细
        /// <summary>
        /// 详细
        /// </summary>
        /// <returns></returns>
        public IQueryable<MoviesGroup> GetQueryable()
        {
            return _dbContext.Set<MoviesGroup>();
        }

        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void SaveChanges()
        {

            _dbContext.SaveChanges();
        }
        #endregion

    }
}
 