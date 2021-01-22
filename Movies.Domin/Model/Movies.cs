using Movies.Domin.Model;
using System;
using System.Collections.Generic;

namespace Movies.Domin
{
    /// <summary>
    /// 影视相关信息
    /// </summary>
    public partial class Movies
    {
        public Movies()
        {
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
            MoviesAndGroup moviesGroupAndRelated = new MoviesAndGroup();
        }
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 电影/电视剧名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 主图
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }

        /// <summary>
        /// 豆瓣评分
        /// </summary>
        public Decimal Douban { get; set; }

        /// <summary>
        /// 上映年
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        /// 上映月
        /// </summary>
        public string ReleaseMonth { get; set; }

        /// <summary>
        /// 上映日
        /// </summary>
        public string ReleaseDay { get; set; }

        /// <summary>
        /// 上映时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 序列
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 分组和影视信息关系表
        /// </summary>
        public virtual MoviesAndGroup MoviesAndGroup { get; set; }

        /// <summary>
        /// 影视简介表
        /// </summary>
        public virtual MoviesIntroduction MoviesIntroduction { get; set; }

        /// <summary>
        /// 剧集
        /// </summary>
        public virtual ICollection<MoviesDramaSeries> MoviesDramaSeries { get; set; }

        /// <summary>
        /// 影视和线路表
        /// </summary>
        public virtual MoviesAndLine MoviesAndLine { get; set; }

    }
}
