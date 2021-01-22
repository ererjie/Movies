using Microsoft.AspNetCore.Mvc;
using Movies.Domin.Dto;
using Movies.Domin.Interface;

namespace Movies.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/movies/moviesgroup/[action]")]
    public class MoviesGroupController : Controller
    {
        private readonly IMoviesGroupRepository _moviesGroupRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moviesGroupRepository"></param>
        public MoviesGroupController(IMoviesGroupRepository moviesGroupRepository)
        {
            _moviesGroupRepository = moviesGroupRepository;
        }

        ///// <summary>
        ///// 分组添加
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[UserAuthorization]
        //public JsonResult Add([FromBody] MoviesGroupParam param)
        //{
        //    var moviesGroup = MoviesGroup.Add(param, _moviesGroupRepository, base.AccountId);
        //    _moviesGroupRepository.SaveChanges();
        //    return base.Json(moviesGroup);
        //}

        ///// <summary>
        ///// 分组更新
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult Edit([FromBody] MoviesGroupParam param)
        //{
        //    var moviesGroup = _moviesGroupRepository.GetQueryable().Where(x => x.Id == param.Id).FirstOrDefault();
        //    if (moviesGroup == null)
        //    {
        //        throw new BusinessException("分组信息不存在或者已经删除");
        //    }
        //    moviesGroup.Edit(param);
        //    _moviesGroupRepository.SaveChanges();
        //    return base.Json(moviesGroup);
        //}

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult Delete([FromBody] JObject param)
        //{
        //    var group = _moviesGroupRepository.GetQueryable().Where(x => x.Id == param["id"].ToString()).FirstOrDefault();
        //    if (string.IsNullOrEmpty(group.Id))
        //    {
        //        throw new EInfrastructure.Core.Configuration.Exception.BusinessException("参数不存在！");
        //    }
        //    group.Delete(group.Id);
        //    _moviesGroupRepository.SaveChanges();
        //    return Json(new { type = "success" });
        //}

        /// <summary>
        /// 分组详情
        /// </summary>
        /// <param name="id">分组id</param>
        /// <returns></returns>
        [HttpGet]
        public GetMoviesGroupDto Get(string id)
        {

            var group = GetMoviesGroupDto.Get(_moviesGroupRepository, id);
            if (group == null)
            {
                throw new EInfrastructure.Core.Configuration.Exception.BusinessException("数据不存在或者已经删除！");
            }
            return group;
        }

        ///// <summary>
        ///// 分组列表
        ///// </summary>
        ///// <param name="formModel"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public JsonResult GetList(MoviesGroupFormModel formModel)
        //{
        //    var groupList = GetMoviesGroupListDto.GetList(_moviesGroupRepository, formModel);
        //    return Json(groupList);
        //}

        ///// <summary>
        ///// 影视相关添加
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult MoviesRelatedAdd([FromBody]MoviesRelatedParam param)
        //{
        //    var group = _moviesGroupRepository.GetQueryable().Where(x => x.Id == param.MoviesGroupId).FirstOrDefault();
        //    if (group==null)
        //    {
        //        throw new BusinessException("分组不存在");
        //    }
        //    MoviesRelated moviesRelated= group.MoviesRelatedAdd(param);
        //    _moviesGroupRepository.SaveChanges();
        //    return Json(new { type = "success" });
        //}

        ///// <summary>
        ///// 影视相关更新
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult MoviesRelatedEdit([FromBody] MoviesRelatedParam param)
        //{
        //    var group = _moviesGroupRepository.GetQueryable().Where(x => x.Id == param.MoviesGroupId).FirstOrDefault();
        //    if (group == null)
        //    {
        //        throw new BusinessException("分组不存在");
        //    }
        //    group.MoviesRelatedEdit(param);
        //    _moviesGroupRepository.SaveChanges();
        //    return Json(new { type = "success" });
        //}
    }
}
