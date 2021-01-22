using EInfrastructure.Core.Configuration.Exception;
using Microsoft.AspNetCore.Mvc;
using Movies.Domin;
using Movies.Domin.Dto;
using Movies.Domin.Interface;
using Movies.Domin.Param;
using Movies.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    [Route("api/movies/movies/[action]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRelatedRepository;

        public MoviesController(IMoviesRepository moviesRelatedRepository)
        {
            _moviesRelatedRepository = moviesRelatedRepository;
        }

        #region 影视信息添加
        /// <summary>
        /// 影视信息添加
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        //[UserAuthorization]
        public JsonResult Add([FromBody]MoviesParam param)
        {
            var related = Domin.Movies.Add(param, _moviesRelatedRepository);
            _moviesRelatedRepository.SaveChanges();//保存
            return Json(new { Type = "success" });

        }
        #endregion

        #region 影视信息更新
        /// <summary>
        /// 影视信息更新
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit([FromBody]MoviesParam param)
        {
            var related = _moviesRelatedRepository.GetQueryable().Where(x => !x.IsDel && x.Id == param.MoviesId).FirstOrDefault();
            if (related == null)
            {
                throw new BusinessException("视频内容以删除或者不存咋");
            }
            related.Edit(param);
            _moviesRelatedRepository.SaveChanges();
            return Json(new { Type = "success" });
        }
        #endregion

        #region 影视信息删除
        /// <summary>
        /// 影视信息删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Del([FromBody] JObject param)
        {
            if (string.IsNullOrWhiteSpace(param["id"].ToString()))
            {
                throw new BusinessException("影视信息id不存在");
            }
            var related = _moviesRelatedRepository.GetQueryable().Where(x => x.Id == param["id"].ToString()).FirstOrDefault();
            if (related == null)
            {
                throw new BusinessException("影视信息不存在或者已删除");
            }
            related.Delete();

            _moviesRelatedRepository.SaveChanges();
            return Json(new { Type = "success" });
        }
        #endregion

        #region 影视信息详情
        /// <summary>
        /// 影视信息详情
        /// </summary>
        /// <param name="id">影视信息id</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(string id)
        {
            var related = GetMoviesDto.Get(id, _moviesRelatedRepository);
            if (related == null)
            {
                throw new BusinessException("影视信息不存在或者已经删除");
            }
            return Json(related);
        }
        #endregion

        #region  影视信息列表
        /// <summary>
        /// 影视信息列表
        /// </summary>
        /// <param name="formModel">搜索条件</param>
        /// <param name="moviesRelatedRepository"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetList(MoviesRelatedFormModel formModel, IMoviesRepository moviesRelatedRepository)
        {
            var relatedList = GetMoviesListDto.GetList(formModel, moviesRelatedRepository);
            return Json(relatedList);
        }
        #endregion

    }
}
