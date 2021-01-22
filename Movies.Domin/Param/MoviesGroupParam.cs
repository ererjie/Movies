using Newtonsoft.Json;

namespace Movies.Domin.Param
{
    public class MoviesGroupParam
    {
        /// <summary>
        /// 影视分组id
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }

        /// <summary>
        /// 影视分组名称
        /// </summary>
        [JsonProperty(PropertyName = "movies_group_name")]
        public string MoviesGroupName { get; set; }

    }


}
