using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Domin.Interface
{
    public interface IMoviesRepository
    {
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>
        void Add(Movies movies);
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="movies"></param>
        void Edit(Movies movies);
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
        IQueryable<Movies> GetQueryable();
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<Movies> GetList(Expression<Func<Movies, bool>> condition);
        #endregion
    }
}
