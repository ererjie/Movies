using Newtonsoft.Json;

namespace Movies.Domin.Param
{
    /// <summary>
    /// 影视信息参数
    /// </summary>
    public class MoviesParam
    {
        /// <summary>
        /// 影视分组Id
        /// </summary>
        [JsonProperty(PropertyName = "movies_group_id")]
        public string MoviesGroupId { get; set; }

        /// <summary>
        /// 影视信息Id
        /// </summary>
        [JsonProperty(PropertyName = "movies_id")]
        public string MoviesId { get; set; }

        /// <summary>
        /// 电影/电视剧名称
        /// </summary>
        [JsonProperty(PropertyName = "movies_name")]
        public string MoviesName { get; set; }

        /// <summary>
        /// 头图
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// 电影路径
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        
    }

    
}
