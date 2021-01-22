using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Domin.Interface
{
    public interface IMoviesGroupRepository
    {
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moviesGroup"></param>
        /// <returns></returns>
        void Add(MoviesGroup moviesGroup);
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moviesGroup"></param>
        void Edit(MoviesGroup moviesGroup);
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        void SaveChanges();

        #endregion

        #region 获取IQueryable方法
        /// <summary>
        /// 获取IQueryable方法
        /// </summary>
        /// <returns></returns>
        IQueryable<MoviesGroup> GetQueryable();
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<MoviesGroup> GetList(Expression<Func<MoviesGroup, bool>> condition);
        #endregion
    }
}
