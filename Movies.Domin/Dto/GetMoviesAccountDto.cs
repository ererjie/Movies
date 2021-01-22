using Movies.Domin.Interface;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Movies.Domin.Dto
{
    /// <summary>
    /// 个人信息详情
    /// </summary>
    public class GetMoviesAccountDto
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
        /// 密码
        /// </summary>
        [JsonProperty(PropertyName = "pass_word")]
        public string Password { get; set; }

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

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonProperty(PropertyName = "is_del")]
        public bool IsDel { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [JsonProperty(PropertyName = "del_time")]
        public DateTime? DelTime { get; set; }

        public static GetMoviesAccountDto Get(IMoviesAccountRepository moviesAccountRepository, string id)
        {
            var moviesAccount = moviesAccountRepository.GetQueryable().Where(x => x.Id == id).Select(x => new GetMoviesAccountDto
            {
                Account=x.Account,
                Phone = x.Phone,
                NickName = x.NickName,
                Password = x.Password,
                CreateTime = x.CreateTime,
                EditTime = x.EditTime,
                LastLoginTime = x.LastLoginTime,
                IsDel = x.IsDel,
                DelTime = x.DelTime

            }).FirstOrDefault();
            return moviesAccount;

        }



    }
}
