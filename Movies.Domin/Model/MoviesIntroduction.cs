using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 影视简介
    /// </summary>
    public class MoviesIntroduction
    {
        /// <summary>
        /// 简介id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 导演
        /// </summary>
        public string DirectorName { get; set; }

        /// <summary>
        /// 演员
        /// </summary>
        public string ActorName { get; set; }

        /// <summary>
        /// 简介内容
        /// </summary>
        public string IntroductionContent { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 影视信息
        /// </summary>
        public virtual Movies Movies { get; set; }
    }
}
