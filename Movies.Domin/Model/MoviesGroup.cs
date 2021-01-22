using System;
using System.Collections.Generic;
using Movies.Domin.Model;

namespace Movies.Domin
{
    /// <summary>
    /// 影视分组
    /// </summary>
    public partial class MoviesGroup
    {
        public MoviesGroup()
        {
            Id = Guid.NewGuid().ToString();
            this.CreateTime = DateTime.Now;
            //MoviesRelated = new List<MoviesRelated>();
        }

        /// <summary>
        /// 影视分组id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 账户id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// 影视分组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public virtual ICollection<MoviesTag> MoviesTag { get; set; }

    }
}
