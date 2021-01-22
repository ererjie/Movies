using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 影视和线路表
    /// </summary>
    public class MoviesAndLine
    {
        /// <summary>
        /// 影视和线路表id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 影视id
        /// </summary>
        public string MoviesId { get; set; }

        /// <summary>
        /// 线路id
        /// </summary>
        public string MoviesLineId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 影视相关信息
        /// </summary>
        public virtual Movies Movies { get; set; }
    }
}
