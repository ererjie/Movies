using Newtonsoft.Json;

namespace Movies.Domin.Param
{
    /// <summary>
    /// 用户前端传参
    /// </summary>
    public class MoviesAccountParam 
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

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

       
        
    }
}
