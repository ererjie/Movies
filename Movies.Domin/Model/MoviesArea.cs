using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 地域
    /// </summary>
    public class MoviesArea
    {
        public string Id { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
