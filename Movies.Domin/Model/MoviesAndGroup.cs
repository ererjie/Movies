using System;

namespace Movies.Domin.Model
{
    /// <summary>
    /// 分组和影视信息关系表
    /// </summary>
    public class MoviesAndGroup
    {
        public MoviesAndGroup()
        {
            Id = Guid.NewGuid().ToString();
            CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 分组和影视信息关系id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public string MoviesGroupId { get; set; }

        /// <summary>
        /// 影视相关id
        /// </summary>
        public string MoviesId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 影视信息
        /// </summary>
        public virtual Movies Movies { get;set;}
    }
}
