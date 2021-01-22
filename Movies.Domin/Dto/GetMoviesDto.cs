using Movies.Domin.Interface;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Movies.Domin.Dto
{
    public class GetMoviesDto
    {
        /// <summary>
        /// 影视分组Id
        /// </summary>
        [JsonProperty(PropertyName = "movies_group_id")]
        public string MoviesGroupId { get; set; }

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

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "cream_time")]
        public DateTime CreamTime { get; set; }

        /// <summary>
        /// 影视信息详情
        /// </summary>
        /// <param name="id">影视信息id</param>
        /// <param name="moviesRelatedRepository"></param>
        /// <returns></returns>
        public static GetMoviesDto Get(string id, IMoviesRepository moviesRelatedRepository)
        {
            var relate = moviesRelatedRepository.GetQueryable().Where(x => !x.IsDel && x.Id == id).Select(x => new GetMoviesDto()
            {
                MoviesGroupId = x.MoviesAndGroup.MoviesGroupId,
                MoviesName = x.Name,
                CreamTime = x.CreateTime

            }).FirstOrDefault();
            return relate;
        }
    }
}
