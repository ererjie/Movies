namespace Movies.Domin.Model
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class MoviesBanner
    {
        /// <summary>
        /// 轮播id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 轮播图名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 轮播图
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// 轮播简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 影视id
        /// </summary>
        public string MoviesId { get; set; }
    }
}
