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
    public class GetMoviesGroupListDto
    {
        /// <summary>
        /// 影视分组名称
        /// </summary>
        [JsonProperty(PropertyName = "movies_group_name")]
        public string MoviesGroupName { get; set; }

        public static List<GetMoviesGroupListDto> GetList(IMoviesGroupRepository moviesGroupRepository, MoviesGroupFormModel formModel)
        {
            Expression<Func<MoviesGroup, bool>> condition = x => !x.IsDel;
            if (!string.IsNullOrWhiteSpace(formModel.MoviesGroupName))
            {
                condition = condition.And(x => x.Name == formModel.MoviesGroupName);
            }
            var groupList = moviesGroupRepository.GetList(condition).Select(x => new GetMoviesGroupListDto()
            {
                MoviesGroupName = x.Name

            }).Skip(formModel.PageSize * (formModel.PageIndex - 1)).Take(formModel.PageSize).AsEnumerable().ToList();
            return groupList;
        }
    }

    public class MoviesGroupFormModel
    {
        /// <summary>
        ///  影视分组名称
        /// </summary>
        [FromQuery(Name = "movies_group_name")]
        public string MoviesGroupName { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [FromQuery(Name = "page_index")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        [FromQuery(Name = "page_size")]
        public int PageSize { get; set; }
    }
}
