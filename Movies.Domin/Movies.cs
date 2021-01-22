using Movies.Domin.Interface;
using Movies.Domin.Param;
using System;

namespace Movies.Domin
{
    public partial class Movies
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="param"></param>
        /// <param name="moviesRelatedRepository"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static Movies Add(MoviesParam param, IMoviesRepository moviesRelatedRepository)
        {
            Movies moviesRelated = new Movies()
            {
              Name = param.MoviesName,
                CreateTime = DateTime.Now,

            };
            moviesRelated.MoviesAndGroup = new Model.MoviesAndGroup()
            {
                MoviesGroupId = param.MoviesGroupId,
                MoviesId = moviesRelated.Id,
                CreateTime = DateTime.Now
            };
            moviesRelatedRepository.Add(moviesRelated);
            return moviesRelated;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="param"></param>
        public void Edit(MoviesParam param)
        {
            this.Name = param.MoviesName;
            this.UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            this.IsDel = true;
            this.DelTime = DateTime.Now;
          
        }
        
    }
}
