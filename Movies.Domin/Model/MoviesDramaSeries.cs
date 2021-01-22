namespace Movies.Domin.Model
{
    /// <summary>
    /// 剧集
    /// </summary>
    public  class MoviesDramaSeries
    {
        /// <summary>
        /// 剧集id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 集数（第几集）
        /// </summary>
        public int DramaSeriesNum { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 影视信息id
        /// </summary>
        public string MoviesId { get; set; }

        /// <summary>
        /// 影视信息
        /// </summary>
        public virtual Movies Movies { get; set; }

        
    }
}
