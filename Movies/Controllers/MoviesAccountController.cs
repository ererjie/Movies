using EInfrastructure.Core.Configuration.Exception;
using EInfrastructure.Core.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Domin;
using Movies.Domin.Dto;
using Movies.Domin.Interface;
using Movies.Domin.Param;
using Movies.Infrastructure;
using Movies.Respository.Mysql;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Movies.Controllers
{
    /// <summary>
    /// 验证权限（要是某个方法不验证，可以在方法头上加[AllowAnonymous]）
    /// </summary>
    [Route("api/movies/moviesaccount/[action]")]
    // [UserAuthorization]
    
    public class MoviesAccountController : BaseController
    {
        private readonly MoviesDbContext _moviesDbContext;
        private readonly IMoviesAccountRepository _moviesAccountRepository;

        public MoviesAccountController(IMoviesAccountRepository moviesAccountRepository, MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
            _moviesAccountRepository = moviesAccountRepository;
        }

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register([FromBody] MoviesAccountParam param)
        {
            var account = _moviesAccountRepository.GetQueryable().Where(x => x.Account == param.Account).FirstOrDefault();
            if (account != null)
            {
                throw new BusinessException("账号已存在！");
            }
            if (param.Account == null)
            {
                throw new BusinessException("账号不能为空！");

            }
            if (string.IsNullOrWhiteSpace(param.Password))
            {
                throw new BusinessException("密码不能为空！");
            }
            var user = AdminAccount.RegisterAdd(param, _moviesAccountRepository);
            // _moviesDbContext.Commit();//保存
            _moviesAccountRepository.SaveChanges();//保存

            if (user == null)
            {
                user = new AdminAccount();
            }
            return base.Json(user);
        }
        #endregion

        /// <summary>
        /// 个人信息更新
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit([FromBody] MoviesAccountParam param)
        {
            var account = _moviesAccountRepository.GetQueryable().Where(x => x.Id == param.Id).FirstOrDefault();
            if (account == null)
            {
                throw new BusinessException("个人信息不存在或者已经被删除");
            }
            account.RegisterEdit(param);
            _moviesAccountRepository.SaveChanges();
            return Json(new { Type = "success" });
        }

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login([FromBody] MoviesAccountParam param)
        {
            var password = SecurityCommon.GetMd5Hash(param.Password, null, false);
            var user = _moviesAccountRepository.GetQueryable().Where(x => x.Account == param.Account).FirstOrDefault();
            if (user == null || user.Account != param.Account)
            {
                throw new BusinessException("账户有误或者账户不存在！");
            }
            if (user.Password != param.Password)
            {
                throw new BusinessException("密码有误！");
            }
            var tokenInfo = user.GetCredion(user.Id);//对传的前端参数加密
            //Response.Headers.Append("UserAuthorization", tokenInfo);
            //Response.Cookies.Append("Token", tokenInfo);
            user.LastLoginTime = DateTime.Now;
            _moviesAccountRepository.SaveChanges();//保存
            return Json(tokenInfo);

        }
        #endregion

        #region 个人信息详情
        /// <summary>
        /// 个人信息详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [UserAuthorization]
        public JsonResult Get()

        {
            var id = base.AccountId;

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new BusinessException("参数有误！");
            }
            var moviesAccount = GetMoviesAccountDto.Get(_moviesAccountRepository, id);
            if (moviesAccount == null)
            {
                throw new BusinessException("信息不存在或者已经删除！");
            }
            return Json(moviesAccount);
        }
        #endregion

        #region 个人信息列表
        /// <summary>
        /// 个人信息列表
        /// </summary>
        /// <param name="formModel">搜索条件</param>
        /// <returns></returns>
        [HttpGet]
        [UserAuthorization]
        public JsonResult GetList([FromBody] MoviesAccountListFormModel formModel)
        {
            var moviesAccountList = GetMoviesAccountListDto.GetList(_moviesAccountRepository, formModel);
            return Json(moviesAccountList);
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [UserAuthorization]
        public JsonResult Del()
        {
            var id = base.AccountId;
            if (!string.IsNullOrWhiteSpace(id))
            {
                var user = _moviesAccountRepository.GetQueryable().Where(x => x.Id == id).FirstOrDefault();
                if (user != null)
                {

                    user.Del(id);
                    _moviesAccountRepository.SaveChanges();//保存
                }
            }
            else
            {
                throw new BusinessException("个人信息不存在或者已经被删除");
            }
            return Json(new { type = "success" });

        }
    }
}
