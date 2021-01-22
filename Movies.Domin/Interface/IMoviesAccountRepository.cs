using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Domin.Interface
{
    /// <summary>
    /// 个人中心接口
    /// </summary>
    public interface IMoviesAccountRepository
    {
        #region 根据用户的得到用户信息
        /// <summary>
        /// 根据用户的得到用户信息
        /// </summary>
        /// <param name="id">用户信息id</param>
        /// <returns></returns>
        AdminAccount GetmoviesAccount(string id);

        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="adminAccount"></param>
        /// <returns></returns>
        void Add(AdminAccount adminAccount);
        #endregion

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="adminAccount"></param>
        void Edit(AdminAccount adminAccount);
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
        IQueryable<AdminAccount> GetQueryable();
        #endregion

        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<AdminAccount> GetList(Expression<Func<AdminAccount, bool>> condition);
        #endregion

    }
}
