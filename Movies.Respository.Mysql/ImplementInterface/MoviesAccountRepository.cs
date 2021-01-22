using Movies.Domin;
using Movies.Domin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Respository.Mysql.ImplementInterface
{
    /// <summary>
    /// 个人中心实现接口
    /// </summary>
    public class MoviesAccountRepository : IMoviesAccountRepository
    {
        private readonly MoviesDbContext _dbContext;
        public MoviesAccountRepository(MoviesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region 添加个人信息
        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="adminAccount"></param>
        public void Add(AdminAccount adminAccount)
        {
            _dbContext.Set<AdminAccount>().Add(adminAccount);


        }


        #endregion

        #region 更新个人信息
        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="moviesAccount"></param>
        public void Edit(AdminAccount adminAccount)
        {
            _dbContext.Set<AdminAccount>().Update(adminAccount);
        }


        #endregion

        #region 得到个人信息详情
        /// <summary>
        /// 得到个人信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminAccount GetmoviesAccount(string id)
        {
            return _dbContext.Set<AdminAccount>().Where(x=>x.Id== id).FirstOrDefault();
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


        #region 获取IQueryable的方法

        /// <summary>
        /// 获取IQueryable的方法
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<AdminAccount> GetQueryable()
        {
            return _dbContext.Set<AdminAccount>();
        }

        #endregion

        #region 根据条件获取实体列表
        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public virtual List<AdminAccount> GetList(Expression<Func<AdminAccount, bool>> condition)
        {
            return _dbContext.Set<AdminAccount>().Where(condition).ToList();

        }

        #endregion
    }
   
}


