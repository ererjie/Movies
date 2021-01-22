using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 标签
    /// </summary>
    public class MoviesTag
    {
        /// <summary>
        /// 标签id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public string MoviesGroupId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public virtual MoviesGroup MoviesGroup { get; set; }
    }
}
