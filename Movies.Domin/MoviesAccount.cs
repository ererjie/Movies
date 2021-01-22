using Movies.Domin.Interface;
using Movies.Domin.Param;
using Movies.Infrastructure;
using Newtonsoft.Json;
using System;

namespace Movies.Domin
{
    public partial class AdminAccount
    {
        #region 添加
        /// <summary>
        /// 注册添加
        /// </summary>
        /// <param name="param">前端传参</param>
        /// <param name="moviesAccountRepository">实体</param>
        /// <returns></returns>
        public static AdminAccount RegisterAdd(MoviesAccountParam param, IMoviesAccountRepository moviesAccountRepository)
        {
            AdminAccount moviesAccount = new AdminAccount()
            {
                Account = param.Account,
                Phone = param.Phone,
                NickName = param.NickName,
                Password = param.Password,
                CreateTime = DateTime.Now,
                LastLoginTime = DateTime.Now
            };
            moviesAccountRepository.Add(moviesAccount);
            return moviesAccount;
        }
        #endregion

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="param">前端参数</param>
        public void RegisterEdit(MoviesAccountParam param)
        {
            this.Phone = param.Phone;
            this.NickName = param.NickName;
            this.Password = param.Password;
            this.EditTime = DateTime.Now;

        }
        #region 获取登录凭证

        /// <summary>
        ///  获取登录凭证
        /// </summary>
        /// <param name="id">个人中心id</param>
        /// <returns></returns>
        public string GetCredion(string id)
        {
            AdminAccount accounts = new AdminAccount()
            {
                Id = id
            };
            string pas = JsonConvert.SerializeObject(accounts);
            string key = "125/*/o56asdddd7d8d4d5d6d490****";
            int leng = key.Length;
            return Tools.Encrypt(pas, key);
        }


        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Del(string id)
        {
            if (id != null)
            {
                this.IsDel = true;
                this.DelTime = DateTime.Now;
            }
        } 
        #endregion

    }



}

