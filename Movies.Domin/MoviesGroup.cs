using Movies.Domin.Interface;
using Movies.Domin.Param;
using System;

namespace Movies.Domin
{
    /// <summary>
    /// 分组
    /// </summary>
    public partial class MoviesGroup
    {
        /// <summary>
        /// 分组添加
        /// </summary>
        /// <param name="param"></param>
        /// <param name="moviesGroupRepository"></param>
        /// <param name="accountId">用户id</param>
        /// <returns></returns>
        public static MoviesGroup Add(MoviesGroupParam param, IMoviesGroupRepository moviesGroupRepository, string accountId)
        {
            MoviesGroup moviesGroup = new MoviesGroup()
            {
                AccountId = accountId,
                Name = param.MoviesGroupName

            };


            moviesGroupRepository.Add(moviesGroup);
            return moviesGroup;
        }

        /// <summary>
        /// 分组更新
        /// </summary>
        /// <param name="param"></param>
        public void Edit(MoviesGroupParam param)
        {
            this.Name = param.MoviesGroupName;
            this.EditTime = DateTime.Now;
        }



        /// <summary>
        /// 分组删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            if (id != null)
            {
                this.IsDel = true;
                this.DelTime = DateTime.Now;
            }
        }

        ///// <summary>
        ///// 添加影视相关
        ///// </summary>
        ///// <param name="param"></param>
        ///// <param name="moviesGroupRepository"></param>
        ///// <param name="accountId"></param>
        ///// <returns></returns>
        //public MoviesRelated MoviesRelatedAdd(MoviesRelatedParam param)
        //{
        //    MoviesRelated moviesRelated = new MoviesRelated()
        //    {
               
        //        MoviesGroupId = param.MoviesGroupId,
        //        MoviesName = param.MoviesName,
        //        Image = param.Image,
        //        Url = param.Url,
        //        CreateTime = DateTime.Now

        //    };
        //    this.MoviesRelated.Add(moviesRelated);
        //    return moviesRelated;
        //}

        ///// <summary>
        ///// 影视相关更新
        ///// </summary>
        ///// <param name="param"></param>
        //public void MoviesRelatedEdit(MoviesRelatedParam param)
        //{
        //    MoviesRelated moviesRelateds = Enumerable.FirstOrDefault<MoviesRelated>(this.MoviesRelated, x => x.Id == param.MoviesRelatedId);
        //    if (moviesRelateds != null)
        //    {
        //        moviesRelateds.Image = param.Image;
        //        moviesRelateds.Url = param.Url;
        //        moviesRelateds.MoviesName = param.MoviesName;
        //        moviesRelateds.UpdateTime = DateTime.Now;
        //    }
        //}
    }
}
