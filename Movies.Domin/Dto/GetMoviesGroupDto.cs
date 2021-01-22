using Movies.Domin.Interface;
using Newtonsoft.Json;
using System.Linq;

namespace Movies.Domin.Dto
{
    public class GetMoviesGroupDto
    {
        /// <summary>
        /// 影视分组id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 影视分组名称
        /// </summary>
        [JsonProperty(PropertyName = "movies_group_name")]
        public string Name { get; set; }

        /// <summary>
        /// 分组详情
        /// </summary>
        /// <param name="moviesGroupRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GetMoviesGroupDto Get(IMoviesGroupRepository moviesGroupRepository,string id)
        {
            var group = moviesGroupRepository.GetQueryable().Where(x => !x.IsDel && x.Id == id).Select(x =>new GetMoviesGroupDto() { Name = x.Name } ).FirstOrDefault();
            return group;
        }
    }
}
