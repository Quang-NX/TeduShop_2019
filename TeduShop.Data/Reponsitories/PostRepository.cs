﻿using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostRepository : IReponsitory<Post>
    {
        IEnumerable<Post> GetAllByTagPasing(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : ReponsitoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTagPasing(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            IQueryable<Post> query = from p in DbContext.Posts
                                     join pt in DbContext.PostTags
                                     on p.Id equals pt.PostId
                                     where pt.TagId == tag && p.Status
                                     orderby p.CreatedDate descending
                                     select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}