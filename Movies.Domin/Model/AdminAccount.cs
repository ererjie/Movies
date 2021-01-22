using System;

namespace Movies.Domin
{
    /// <summary>
    /// 账户
    /// </summary>
    public partial  class AdminAccount
    {
        public AdminAccount()
        {
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }
        /// <summary>
        /// Id
        /// </summary>
        public  string Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 账户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }

    }
}
