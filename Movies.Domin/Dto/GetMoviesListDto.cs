using EInfrastructure.Core.Config.Entities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Movies.Domin.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Movies.Domin.Dto
{
    public class GetMoviesListDto
    {
        /// <summary>
        /// 影视信息id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

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

        public static List<GetMoviesListDto> GetList(MoviesRelatedFormModel formModel, IMoviesRepository moviesRelatedRepository)
        {
            Expression<Func<Movies, bool>> expression = x => !x.IsDel;
            if (!string.IsNullOrWhiteSpace(formModel.MoviesName))
            {
                expression = expression.And(x => x.Name == formModel.MoviesName);
            }
            var relatedList = moviesRelatedRepository.GetList(expression).Select(x => new GetMoviesListDto()
            {
                Id=x.Id,
                MoviesGroupId=x.MoviesAndGroup.MoviesGroupId,
                MoviesName=x.Name,
            }).Skip(formModel.PageSize * (formModel.PageIndex - 1)).Take(formModel.PageSize).AsEnumerable().ToList();
            return relatedList;
        }
    }

    public class MoviesRelatedFormModel
    {
        /// <summary>
        /// 电影/电视剧名称
        /// </summary>
        [FromForm(Name = "movies_name")]
        public string MoviesName { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [FromForm(Name = "page_index")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        [FromForm(Name = "page_size")]
        public int PageSize { get; set; }
    }
}
