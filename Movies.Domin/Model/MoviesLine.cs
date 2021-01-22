using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 线路
    /// </summary>
    public class MoviesLine
    {
        public string Id { get; set; }

        /// <summary>
        /// 线路路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 影视信息id
        /// </summary>
        public string MoviesRelatedId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 影视信息
        /// </summary>
        public virtual Movies Movies { get; set; }
    }
}


