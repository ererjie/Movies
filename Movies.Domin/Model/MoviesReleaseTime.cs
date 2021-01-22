using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 上映时间
    /// </summary>
    public class MoviesReleaseTime
    {
        public string Id { get; set; }

        /// <summary>
        /// 上映年份
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
