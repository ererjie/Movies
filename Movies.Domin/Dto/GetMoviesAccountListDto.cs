using EInfrastructure.Core.Config.Entities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Movies.Domin.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Domin.Dto
{
    public class GetMoviesAccountListDto
    {
        /// <summary>
        /// 账户
        /// </summary>
        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty(PropertyName = "nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 账户创建时间
        /// </summary>
        [JsonProperty(PropertyName = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty(PropertyName = "edit_time")]
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        [JsonProperty(PropertyName = "last_login_time")]
        public DateTime? LastLoginTime { get; set; }

        public static List<GetMoviesAccountListDto> GetList(IMoviesAccountRepository moviesAccountRepository,MoviesAccountListFormModel formModel)
        {
            Expression<Func<AdminAccount, bool>> condition = x => !x.IsDel;
            if (!string.IsNullOrWhiteSpace( formModel.Account))//IsNullOrWhiteSpace可以判断(null和""和"    ")
            {
                condition = condition.And(x => x.Account == formModel.Account);
            }
            if (!string.IsNullOrWhiteSpace(formModel.Phone))
            {
                condition = condition.And(x => x.Phone == formModel.Phone);
            }
            if (!string.IsNullOrWhiteSpace(formModel.NickName))
            {
                condition = condition.And(x => x.NickName == formModel.NickName);
            }
            var list = moviesAccountRepository.GetList(condition).Select(x => new GetMoviesAccountListDto()
            {

                Account=x.Account,
                Phone = x.Phone,
                NickName = x.NickName,
                CreateTime = x.CreateTime,
                EditTime = x.EditTime,
                LastLoginTime = x.LastLoginTime,

            }).Skip(formModel.PageSize * (formModel.PageIndex- 1)).Take(formModel.PageSize).AsEnumerable().ToList();//AsEnumerable延迟加载，当真正使用（数据）时才执行sql语句
            return list;
        }

    }

    #region  搜索字段
    /// <summary>
    /// 搜索字段
    /// </summary>
    public class MoviesAccountListFormModel
    {
        /// <summary>
        /// 账户
        /// </summary>
        [FromQuery(Name = "account")]
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [FromQuery(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [FromQuery(Name = "nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [FromQuery(Name = "page_index")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        [FromQuery(Name = "page_size")]
        public int PageSize { get; set; }
    }
    #endregion
}
